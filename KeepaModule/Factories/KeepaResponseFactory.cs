using KeepaModule.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Factories
{
    /// <summary>
    /// Keepa Response Factory 
    /// </summary>
    public class KeepaResponseFactory
    {
        /// <summary>
        /// Creates response objects from Json strings
        /// </summary>
        /// <param name="jsonTask"></param>
        /// <returns></returns>
        public static Task<Response> Create(Task<string> jsonTask)
        {
            //Convert Task<string> to Task<Response> via JsonDeserializer
            Task<Response> ConvertedTaskObject = jsonTask.ContinueWith(t => JsonConvert.DeserializeObject<Response>(t.Result));
            return ConvertedTaskObject;
        }
    }
}
