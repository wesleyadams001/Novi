using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Constants;
using XModule.Interfaces;
using XModule.Services;

namespace KeepaModule.Factories
{
    public class KeepaRequestFactory : IRequestFactoryService
    {
        
        readonly Func<Enums.ApiSpecificRequestTypes, IRequest> factoryFactory;

        public KeepaRequestFactory(Func<Enums.ApiSpecificRequestTypes, IRequest> factoryFactory)
        {
            this.factoryFactory = factoryFactory;
        }

        public IRequest Create(Enums.ApiSpecificRequestTypes requestType)
        {
            return factoryFactory(requestType);
        }
        
    }
}
