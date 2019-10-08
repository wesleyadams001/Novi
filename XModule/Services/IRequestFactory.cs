using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using XModule.Models;
using static XModule.Constants.Enums;

namespace XModule.Services
{
    /// <summary>
    /// Interface that request factories should implement
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// The factory type
        /// </summary>
        FactoryType FactoryType {get;}
    }
}
