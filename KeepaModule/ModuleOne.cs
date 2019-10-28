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
    public class ModuleOne : INoviModule, IModule//
    {
        private readonly IUnityContainer _container;
        private readonly ILogger _logger;
        private KeepaRequestFactory _reqFactory;
        private Client _keepaReqClient;
        
        /// <summary>
        /// Entry point for the module to insert unity container
        /// </summary>
        /// <param name="container"></param>
        public ModuleOne(IUnityContainer container, ILoggerFactory loggerFactory)
        {
            if (container == null)
            {
                this._logger.Error("Container is null");
            }
            _logger = loggerFactory.Create<ModuleOne>();
            try
            {
                _container = container;
            }
            catch(Exception e)
            {
                this._logger.Error("Failed to assign container");
            }
            
            this._logger.Debug("Created factory with key of:" + Properties.Settings.Default.CurrentKey);
            this._reqFactory = new KeepaRequestFactory(Properties.Settings.Default.CurrentKey);
            this._logger.Debug("Created new Client of type:" + typeof(Client));
            this._keepaReqClient = new Client();

            try
            {
                //Register available requestservice
                _container.RegisterType<IAvailableRequestsService, AvailableRequests>();
            }
            catch (Exception e)
            {
                this._logger.Error("Failed to register " + typeof(IAvailableRequestsService) + " as " + typeof(AvailableRequests) + " with error: " + e.Message);
            }



            try
            {
                //Register data processing components
                _container.RegisterType<INoviModule, ModuleOne>();

            }
            catch (Exception e)
            {
                this._logger.Error("Failed to register " + typeof(INoviModule) + " with error: " + e.Message);
            }
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
            //System.Windows.MessageBox.Show($"{nameof(ModuleOne)} has been initialized");
            this._logger.Debug("Initilized Method of: " +typeof(ModuleOne));


        }

        /// <summary>
        /// Processes request objects that thiis module recieves
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="outblock"></param>
        public void Process(BufferBlock<RequestObject> buffer)
        {
            //filter out non relevant items
            Predicate<RequestObject> RequestFilter = (RequestObject r) => { return r.ApiName == RequestTypes.Keepa; };

            var linkops = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };

            //create a recieving bufferblock
            var bufferblock = new BufferBlock<RequestObject>();

            //transform Request objects into request strings
            var Transblock = new TransformBlock<RequestObject, string>(x => {
                
                var requestString = this._reqFactory.Create(x.RequestName, x.ParameterList);
                this._logger.Debug("Created" + requestString);
                return requestString;
            });

            //Sends request to API
            var RequestBlock = new TransformBlock<string, Task<string>>(async x =>
            {

               string response = await this._keepaReqClient.DownloadAsync(x);
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

                //Insert over DbContext
                Operations.Insert(filter.bestSellerBlock, context);
                Operations.Insert(filter.categoryBlock, context);
                Operations.Insert(filter.eanBlock, context);
                Operations.Insert(filter.fbaFeesBlock, context);
                Operations.Insert(filter.featuresBlock, context);
                Operations.Insert(filter.freqBoughtBlock, context);
                Operations.Insert(filter.languagesBlock, context);
                Operations.Insert(filter.mostRatedSellerBlock, context);
                Operations.Insert(filter.priceHistoryBlock, context);
                Operations.Insert(filter.productBlock, context);
                Operations.Insert(filter.sellerBlock, context);
                Operations.Insert(filter.sellerItemBlock, context);
                Operations.Insert(filter.statisticsBlock, context);
                Operations.Insert(filter.upcBlock, context);
                Operations.Insert(filter.variationBlock, context);

                //save changes
                context.SaveChanges();
            }
           
            //Links
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