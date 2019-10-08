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

        public Pipe(IUnityContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// The method that posts a request to the data pipeline
        /// </summary>
        /// <param name="request"></param>
        public void Post(RequestObject request)
        {
            
            //var startBlock = new BufferBlock<RequestObject>();

            //var broadcastBlock = new BufferBlock<RequestObject>();

            //var outBlock = new BufferBlock<string>();

            ////resolve consumers to enumerable
            //var modules = this.container.Resolve<IEnumerable<INoviModule>>();

            //for(int x = 0; x< modules.Count(); x++)
            //{
            //    //call each to process from the block
            //    modules.ElementAt(x).Process(broadcastBlock, out outBlock);
            //}
        }

        
    }
}
