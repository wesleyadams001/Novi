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
using System.IO;
using System.Reflection;
using Autofac;

namespace prism7.Pipeline
{
    /// <summary>
    /// Data pipeline object
    /// </summary>
    public class Pipe
    {
        private IComponentContext _container;
        private ILoggerFactory logFac;
        private ILogger logger;

        public Pipe(IComponentContext container, ILoggerFactory logger)
        {
            this._container = container;
            this.logFac = logger;
            this.logger = logger.Create<Pipe>();
            this.logger.Debug("Created Pipeline");
         
        }

        /// <summary>
        /// The method that posts a request to the data pipeline
        /// </summary>
        /// <param name="request"></param>
        public void Post(RequestObject request)
        {

            var startBlock = new BufferBlock<RequestObject>();

            var broadcastBlock = new BufferBlock<RequestObject>();
            
            var t = Task.Run(() =>
            {
                var components = this._container.Resolve<IEnumerable<INoviModule>>();

                for(int x=0; x< components.Count(); x++)
                {
                    //call each to process from the block
                    components.ElementAt(x).Process(broadcastBlock);
                }
                    
            });
            

            startBlock.LinkTo(broadcastBlock, new DataflowLinkOptions { PropagateCompletion = true });

            //post request
            this.logger.Debug("Posted message to Pipeline" + request.RequestName);
            startBlock.Post(request);
        }

       


    }
}
