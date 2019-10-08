using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;
using XModule.Services;

namespace XModule.Interfaces
{
    public interface IFacFactory
    {
        /// <summary>
        /// The factory that creates factories
        /// </summary>
        /// <param name="ro"></param>
        /// <returns></returns>
        IRequestFactory Create(RequestObject ro);
    }
}
