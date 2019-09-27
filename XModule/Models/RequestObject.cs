using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;

namespace XModule.Models
{
    public class RequestObject
    {
        public RequestObject()
        {

        }

        public RequestObject(string requestName, string apiName)
        {
            this.RequestName = requestName;
            this.ApiName = apiName;
            this.ParameterList = new List<Pair<string, object>>();
        }

        /// <summary>
        /// The name of the request
        /// </summary>
        public string RequestName { get; set; }

        /// <summary>
        /// The name of the API to which the request belongs
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// The list of parameters that belong to a method with their associated types
        /// </summary>
        public List<Pair<string,object>> ParameterList { get; set; }
    }
}
