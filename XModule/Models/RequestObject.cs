using NodaTime;
using Prism.Mvvm;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;
using static XModule.Constants.Enums;

namespace XModule.Models
{
    public class RequestObject : BindableBase
    {
        /// <summary>
        /// Constructor used when not presetting the request name and apiname
        /// </summary>
        public RequestObject()
        {
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
        }

        

        /// <summary>
        /// Constructor used when initializing with the target requestname and apiname
        /// </summary>
        /// <param name="requestName"></param>
        /// <param name="apiName"></param>
        public RequestObject(string requestName, RequestTypes apiName)
        {
            this.RequestName = requestName;
            this.ApiName = apiName;
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
        }

        /// <summary>
        /// Returns a hash of the request object
        /// </summary>
        /// <returns></returns>
        public long GetHash()
        {
            //Instant now = SystemClock.Instance.GetCurrentInstant();
            long hash = (long)this.RequestName.GetHashCode() + (long)this.ApiName.GetHashCode();
            for(int x =0; x< this.ParameterList.Count; x++)
            {
                hash += this.ParameterList.ElementAt(x).First.GetHashCode() + this.ParameterList.ElementAt(x).Second.GetHashCode();
            }
            
            return hash;
        }
        
        /// <summary>
        /// The name of the request
        /// </summary>
        public string RequestName { get; set; }

        /// <summary>
        /// The name of the API to which the request belongs
        /// </summary>
        public RequestTypes ApiName { get; set; }

        /// <summary>
        /// Backing field of parameter list
        /// </summary>
        private ObservableCollection<Pair<string, object>> list;

        /// <summary>
        /// The list of parameters that belong to a method with their associated types
        /// </summary>
        public ObservableCollection<Pair<string,object>> ParameterList
        {
            get { return list; }
            set { list = value; OnPropertyChanged("ParameterList"); }
        }
    }
}
