using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;
using XModule.Services;

namespace prism7.Services
{
    public class ActiveRequestsService : IActiveRequestsService
    {
        private ObservableCollection<RequestObject> requestObjects;

        public ObservableCollection<RequestObject> GetRequests()
        {
            this.requestObjects = new ObservableCollection<RequestObject>();

            //Reload to refresh persistence
            Properties.Settings.Default.Reload();

            //if there are more than 0 items 
            if (Properties.Settings.Default.ActiveRequests.Count > 0)
            {
                //pull arr of strings out of properties xml
                string[] arr = new string[Properties.Settings.Default.ActiveRequests.Count];
                Properties.Settings.Default.ActiveRequests.CopyTo(arr, 0);

                for(int x =0; x< arr.Length; x++)
                {
                    var obj = JsonConvert.DeserializeObject<RequestObject>(arr[x]);
                    this.requestObjects.Add(obj);
                }
            }
            return this.requestObjects;
        }

        
    }
}
