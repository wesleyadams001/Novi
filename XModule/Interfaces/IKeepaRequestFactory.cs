using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;
using XModule.Services;

namespace XModule.Interfaces
{
    public interface INtfsRequestFactory : IRequestFactory
    {
        /// <summary>
        /// Create method
        /// </summary>
        /// <returns></returns>
        IRequest Create(RequestObject ro);
    }
}
