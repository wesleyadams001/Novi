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
    /// Data pipeline
    /// </summary>
    public class Pipe
    {
        private IComponentContext _container;
        private ILoggerFactory logFac;
        private ILogger logger;
        private IEnumerable<INoviModule> _components;
        private BufferBlock<RequestObject> _startBlock;
        private BufferBlock<RequestObject> _broadcastBlock;

        public Pipe(IComponentContext container, ILoggerFactory logger)
        {
            this._container = container;
            this.logFac = logger;
            this.logger = this.logFac.Create<Pipe>();
            this.logger.Debug("Created Pipeline");
            this._startBlock = new BufferBlock<RequestObject>();

            this._broadcastBlock = new BufferBlock<RequestObject>();
            this._components = this._container.Resolve<IEnumerable<INoviModule>>();
        }

        /// <summary>
        /// The method that posts a request to the data pipeline
        /// </summary>
        /// <param name="request"></param>
        public void Post(RequestObject request)
        {

            var t = Task.Run(() =>
            {

                for(int x=0; x< this._components.Count(); x++)
                {
                    //call each to process from the block
                    this._components.ElementAt(x).Process(this._broadcastBlock);
                }
                    
            });
            

            this._startBlock.LinkTo(this._broadcastBlock, new DataflowLinkOptions { PropagateCompletion = true });

            //post request
            this.logger.Debug("Posted message to Pipeline" + request.RequestName);
            this._startBlock.Post(request);
        }

        /// <summary>
        /// Completes the pipeline
        /// </summary>
        public void StopPipeline()
        {
            this._startBlock.Complete();
        }

    }
}
