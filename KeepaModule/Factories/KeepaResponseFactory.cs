using NtfsModule.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtfsModule.Factories
{
    /// <summary>
    /// Ntfs Response Factory 
    /// </summary>
    public class NtfsResponseFactory
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
