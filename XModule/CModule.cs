using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;

namespace XModule
{
    /// <summary>
    /// This module acts as kind of definitions donkey
    /// </summary>
    public class XModule : IModule
    {
        private readonly IUnityContainer _container;

        public XModule(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException($"{nameof(container)}");
            }

            _container = container;
        }

        public void Initialize()
        {
           // _container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());
         
        }
    }
}
