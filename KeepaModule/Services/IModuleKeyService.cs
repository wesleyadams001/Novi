using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Services
{
    /// <summary>
    /// The Internal Module Key serice that orients keys within the module
    /// </summary>
    public interface IModuleKeyService
    {
        /// <summary>
        /// Method that posts internally chosen key
        /// </summary>
        /// <returns></returns>
        string GetKeys();
    }
}
