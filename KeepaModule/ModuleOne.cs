using System;
using System.Threading.Tasks.Dataflow;
using KeepaModule.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using XModule.Interfaces;
using XModule.Models;
using XModule.Services;

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
            throw new NotImplementedException();
        }
    }
}