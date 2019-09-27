using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using static XModule.Constants.Enums;

namespace XModule.Services
{
    /// <summary>
    /// Interface that request factories should implement
    /// </summary>
    public interface IRequestFactoryService
    {
        /// <summary>
        /// Create method
        /// </summary>
        /// <returns></returns>
        IRequest Create(ApiSpecificRequestTypes type);
    }
}
