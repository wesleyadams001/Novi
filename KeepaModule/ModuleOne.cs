using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Autofac;
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
    public class ModuleOne : Module, INoviModule, IModule
    {
        private ILoggerFactory _loggerFac;
        private ILogger _logger;
        private KeepaRequestFactory _reqFactory;
        private KeepaRecordFactory _recordFactory;
        private Client _keepaReqClient;
        private Allocator _keepaAllocator;
        private KeepaContext _context;
        private const string baseUrl = "https://api.keepa.com/";

        /// <summary>
        /// Entry point for the module to insert unity container
        /// </summary>
        /// <param name="container"></param>
        public ModuleOne(ILoggerFactory loggerFac)
        {
            //Creates the logger factory and resolves a logger
            this._loggerFac = loggerFac;
            this._logger = this._loggerFac.Create<ModuleOne>();

            //Builds a request factory with the associated key
            this._logger.Debug("Created factory with key of:" + Properties.Settings.Default.CurrentKey);
            this._reqFactory = new KeepaRequestFactory(baseUrl);
            this._recordFactory = new KeepaRecordFactory(loggerFac);

            //creates a new client
            this._logger.Debug("Created new Client of type:" + typeof(Client));
            this._keepaReqClient = new Client();

            //Create the records filter
            this._logger.Debug("Created new Allocator.");
            this._keepaAllocator = new Allocator();

            
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
        /// Load method of Autofac Module
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //Register available requestservice
            builder.RegisterType<AvailableRequests>().As<IAvailableRequestsService>();
           
            builder.RegisterType<ModuleOne>().As<INoviModule>();
          
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
               
                var list = this._recordFactory.Create(x);
                return list;
            });

            //Expand enumerable to individual
            var ExpandedBlock = new TransformManyBlock<List<IRecord>, IRecord>(array => array);
            var StagingBlock = new BufferBlock<IRecord>();

            //Filter IRecords into appropriate tables
            //Keep the active Context Graph small by using a new context for each Unit of Work
            var insertBlock = new ActionBlock<IRecord>((a) =>
            {
               
                this._keepaAllocator.Filter(a);

            });
           
            //Links
            buffer.LinkTo(bufferblock, linkops, RequestFilter);
            bufferblock.LinkTo(Transblock, linkops);
            Transblock.LinkTo(RequestBlock, linkops);
            RequestBlock.LinkTo(ResponseBlock, linkops);
            ResponseBlock.LinkTo(RecordBlock, linkops);
            RecordBlock.LinkTo(ExpandedBlock, linkops);
            ExpandedBlock.LinkTo(StagingBlock, linkops);
            StagingBlock.LinkTo(insertBlock, linkops);
           
        }

        public void Initialize()
        {
            
        }
    }
}