using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Constants;
using XModule.Interfaces;
using XModule.Models;
using XModule.Services;
using XModule.Tools;

namespace KeepaModule.Factories
{
    public class KeepaRequestFactory : IKeepaRequestFactory
    {
        public Enums.FactoryType FactoryType => Enums.FactoryType.Keepa;

        readonly Func<RequestObject, IRequest> factoryFactory;

        public KeepaRequestFactory(Func<RequestObject, IRequest> factoryFactory)
        {
            this.factoryFactory = factoryFactory;
        }

        public IRequest Create(RequestObject requestObject)
        {
            return factoryFactory(requestObject);
        }
        
    }
}
