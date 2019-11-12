using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using XModule.Models;

namespace XModule.Interfaces
{
    public interface INoviModule : IModule
    {

        /// <summary>
        /// Method that processes Request objects and divests them to appropriate dlls
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="outblock"></param>
        void Process(BufferBlock<RequestObject> buffer);//buffer of strings are insert statements , out BufferBlock<string> outblock

        /// <summary>
        /// Gets the appropriate schema based on request object
        /// </summary>
        /// <param name="ro"></param>
        /// <returns></returns>
        string GetSchema(RequestObject ro); //schema as string SQL
    }
}
