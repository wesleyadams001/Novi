using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using XModule.Models;
using XModule.Services;
using static XModule.Constants.Enums;

namespace AclProcessor.Factory
{
    public class RequestFactory : IFacFactory
    {

        private IRequestFactory factory;
        private IUnityContainer container;

        public RequestFactory(IUnityContainer container)
        {
           
            this.container = container;
        }

        public IRequestFactory Create(RequestObject requestObject)
        {
           
            switch (requestObject.ApiName)
            {
                case RequestTypes.Ntfs:
                    this.factory = this.container.Resolve<INtfsRequestFactory>();
                    break;
                
            }
            return this.factory;
        }

    }
}
