using Prism.Mvvm;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;

namespace XModule.Models
{
    public class RequestObject : BindableBase
    {
        public RequestObject()
        {

        }
        private ObservableCollection<Pair<string, object>> list;
        public RequestObject(string requestName, string apiName)
        {
            this.RequestName = requestName;
            this.ApiName = apiName;
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
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
        public ObservableCollection<Pair<string,object>> ParameterList
        {
            get { return list; }
            set { list = value; OnPropertyChanged("ParameterList"); }
        }
    }
}
