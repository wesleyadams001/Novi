using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Services
{
    public interface IPluginService
    {
        /// <summary>
        /// Link groups associated with a particular plugin
        /// </summary>
        /// <returns></returns>
        LinkGroup GetLinkGroup();

        /// <summary>
        /// Configures an API requester using the associated API key
        /// </summary>
        /// <param name="key"></param>
        void ActivateApi(string key);

        /// <summary>
        /// Sends a request to the API's end point
        /// Necessary for future scheduler service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool Acquire(string request);

        /// <summary>
        /// Returns an interface that represents a database context associated with a plugin
        /// </summary>
        /// <returns></returns>
        DbContext GetDataContext();

        


    }
}
