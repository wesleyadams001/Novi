using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;

namespace prism7.Services
{
    public class KeyService : IKeyService
    {
        /// <summary>
        /// Accesses the settings file to get the current keys as a string 
        /// </summary>
        private string Keys = Properties.Settings.Default.ApiKeys;

        /// <summary>
        /// Accesses the settings file to get the current connection strings
        /// </summary>
        private string ConnStrings = Properties.Settings.Default.ConnectionStrings;

        /// <summary>
        /// An observable collection of Api Keys
        /// </summary>
        private ObservableConcurrentDictionary<string, string> ApiKeys;

        /// <summary>
        /// An observable collection of Connection Strings
        /// </summary>
        private ObservableConcurrentDictionary<string, string> ConnectionStrings;

        public KeyService()
        {
            
        }

        /// <summary>
        /// Returns the currently stored set of Connection Strings
        /// </summary>
        /// <returns></returns>
        public ObservableConcurrentDictionary<string, string> GetConnections()
        {
            this.ConnectionStrings = JsonConvert.DeserializeObject<ObservableConcurrentDictionary<string, string>>(this.ConnStrings);

            return this.ConnectionStrings;
        }

        /// <summary>
        /// Returns the currently stored set of Api Keys
        /// </summary>
        /// <returns></returns>
        public ObservableConcurrentDictionary<string, string> GetKeys()
        {
            //Deserialize the ApiKeys
            this.ApiKeys = JsonConvert.DeserializeObject<ObservableConcurrentDictionary<string, string>>(this.Keys);

            return this.ApiKeys;
        }
    }
}
