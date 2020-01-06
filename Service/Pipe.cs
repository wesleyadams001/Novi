using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using XModule.Interfaces;
using XModule.Models;

namespace Service
{
    /// <summary>
    /// Data pipeline
    /// </summary>
    public class Pipe
    {
        private IComponentContext _container;
        private IEnumerable<INoviModule> _components;
        private BufferBlock<RequestObject> _startBlock;
        private BufferBlock<RequestObject> _broadcastBlock;

        public Pipe(IComponentContext container)
        {
            this._container = container;
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
            //run task to process
            var t = Task.Run(() =>
            {

                for (int x = 0; x < this._components.Count(); x++)
                {
                    //call each to process from the block
                    this._components.ElementAt(x).Process(this._broadcastBlock);
                }

            });

            //Link start block to broad casting block
            this._startBlock.LinkTo(this._broadcastBlock, new DataflowLinkOptions { PropagateCompletion = true });

            //post request
            this._startBlock.Post(request);
        }
    }
}
