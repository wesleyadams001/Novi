using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using KeepaModule.DataAccess;
using KeepaModule.DataAccess.Entities;
using KeepaModule.DataAccess.Entities.Actions;
using KeepaModule.DataAccess.Records;
using KeepaModule.Factories;
using KeepaModule.Models;
using KeepaModule.Services;
using KeepaModule.Tools;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using XModule.Interfaces;
using XModule.Models;
using XModule.Services;
using static XModule.Constants.Enums;

namespace KeepaModule
{
    public class ModuleOne : INoviModule, IModule
    {
        private readonly IUnityContainer _container;
        
        /// <summary>
        /// Entry point for the module to insert unity container
        /// </summary>
        /// <param name="container"></param>
        public ModuleOne(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException($"{nameof(container)}");
            }

            _container = container;
        }

        /// <summary>
        /// Gets the Schema associated with this module
        /// </summary>
        /// <param name="ro"></param>
        /// <returns></returns>
        public string GetSchema(RequestObject ro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the module and registers relevant types
        /// </summary>
        public void Initialize()
        {
            System.Windows.MessageBox.Show($"{nameof(ModuleOne)} has been initialized");
            
            //Register available requestservice
            _container.RegisterType<IAvailableRequestsService, AvailableRequests>(new ContainerControlledLifetimeManager());

            //Register data processing components
            _container.RegisterType<INoviModule, ModuleOne>();
        }

        /// <summary>
        /// Processes request objects that thiis module recieves
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="outblock"></param>
        public void Process(BufferBlock<RequestObject> buffer, out BufferBlock<string> outblock)
        {
            //filter out non relevant items
            Predicate<RequestObject> RequestFilter = (RequestObject r) => { return r.ApiName == RequestTypes.Keepa; };

            var linkops = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };

            //create a recieving bufferblock
            var bufferblock = new BufferBlock<RequestObject>();

            //create a request factory instance
            var fac = new KeepaRequestFactory("");

            //transform Request objects into request strings
            var Transblock = new TransformBlock<RequestObject, string>(x => {
                
                var requestString = fac.Create(x.RequestName, x.ParameterList);
                
                return requestString;
            });

            var client = new Client();

            //Sends request to API
            var RequestBlock = new TransformBlock<string, Task<string>>(async x =>
            {

               string response = await client.DownloadAsync(x);
               return response;

            });

            //Transforms response string to response object
            var ResponseBlock = new TransformBlock<Task<string>, Response>(x =>
            {
                Task<Response> response = KeepaResponseFactory.Create(x);
                return response;
            });

            //Transforms responses to Record blocks
            var RecordBlock = new TransformBlock<Response, List<IRecord>>(x => {
                KeepaRecordFactory recordFactory = new KeepaRecordFactory();
                var list = recordFactory.Create(x);
                return list;
            });

            //Expand enumerable to individual
            var ExpandedBlock = new TransformManyBlock<List<IRecord>, IRecord>(array => array);
            var StagingBlock = new BufferBlock<IRecord>();

            //Filter IRecords into appropriate tables
            KeepaFilter filter = new KeepaFilter();
            filter.Allocate(StagingBlock);

            using (var context = new KeepaContext()) {
                Operations.Insert(filter.bestSellerBlock, context);
                

            }
           

            buffer.LinkTo(bufferblock, linkops, RequestFilter);
            bufferblock.LinkTo(Transblock, linkops);
            Transblock.LinkTo(RequestBlock, linkops);
            RequestBlock.LinkTo(ResponseBlock, linkops);
            ResponseBlock.LinkTo(RecordBlock, linkops);
            RecordBlock.LinkTo(ExpandedBlock, linkops);
            ExpandedBlock.LinkTo(StagingBlock, linkops);

           
        }
    }
}