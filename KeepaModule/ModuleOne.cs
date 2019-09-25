using System;
using KeepaModule.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using XModule.Services;

namespace KeepaModule
{
    public class ModuleOne : IModule
    {
        private readonly IUnityContainer _container;
        
        public ModuleOne(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException($"{nameof(container)}");
            }

            _container = container;
        }

        public void Initialize()
        {
            System.Windows.MessageBox.Show($"{nameof(ModuleOne)} has been initialized");
            
            //Register available requestservice
            _container.RegisterType<IAvailableRequestsService, AvailableRequests>(new ContainerControlledLifetimeManager());
        }
    }
}