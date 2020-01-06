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
            Task<Response> ConvertedTaskObject = null;
            //try catch
            try { 

                ConvertedTaskObject = jsonTask.ContinueWith(t => JsonConvert.DeserializeObject<Response>(t.Result));
            }
            catch(Exception e)
            {
                //log e
            }
            return ConvertedTaskObject;
        }
    }
}
