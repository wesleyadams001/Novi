using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using XModule.Services;
using KeepaModule.Models;
using System.Reflection;

namespace KeepaModule.Services
{
    public class AvailableRequests : IAvailableRequestsService
    {
        private ObservableConcurrentCollection<string> typesCollection;
        
        public ObservableConcurrentCollection<string> GetRequests()
        {
            this.typesCollection = new ObservableConcurrentCollection<string>();

            //Use parent type as a root
            Type parentType = typeof(KeepaRequest);

            //Look at current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Get associated types
            Type[] types = assembly.GetTypes();

            //Get subclasses
            var subclasses = types.Where(t => t.IsSubclassOf(parentType));

            //Get names of subclasses
            var names = subclasses.Select(t => t.Name);

            //add to types collection
            typesCollection.AddFromEnumerable<string>(names);

            return this.typesCollection;
        }
    }
}
