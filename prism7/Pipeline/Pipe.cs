using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;
using System.Threading.Tasks.Dataflow;
using Microsoft.Practices.Unity;
using prism7.Factory;
using XModule.Constants;
using XModule.Interfaces;

namespace prism7.Pipeline
{
    /// <summary>
    /// Data pipeline object
    /// </summary>
    public class Pipe
    {
        private IUnityContainer container;
        private ILogger logger;
        public Pipe(IUnityContainer container, ILoggerFactory logger)
        {
            this.logger = logger.Create<Pipe>();
            this.logger.Debug("Created Pipeline");
            this.container = container;
        }

        /// <summary>
        /// The method that posts a request to the data pipeline
        /// </summary>
        /// <param name="request"></param>
        public void Post(RequestObject request)
        {

            var startBlock = new BufferBlock<RequestObject>();

            var broadcastBlock = new BufferBlock<RequestObject>();

            //var outBlock = new BufferBlock<string>();

            this.logger.Debug("Attempted Resolution of each " + typeof(INoviModule));
            //resolve consumers to enumerable
            var modules = this.container.Resolve<IEnumerable<INoviModule>>();
            int count = modules.Count();
            for (int x = 0; x < modules.Count(); x++)
            {
                //call each to process from the block
                modules.ElementAt(x).Process(broadcastBlock);
            }

            //modules.Process(broadcastBlock);

            startBlock.LinkTo(broadcastBlock, new DataflowLinkOptions { PropagateCompletion = true });

            //post request
            this.logger.Debug("Posted message to Pipeline" + request.RequestName);
            startBlock.Post(request);
        }

        
    }
}
