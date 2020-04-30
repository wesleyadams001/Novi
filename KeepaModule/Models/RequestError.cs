using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtfsModule.Models
{
    /// <summary>
    /// Contains information about an API error.
    /// </summary>
    public class RequestError
    {

        /// <summary>
        /// Override of the To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
