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
using XModule.Tools;

namespace KeepaModule.Services
{
    public class AvailableRequests : IAvailableRequestsService
    {
        private List<Pair<string, string>> typesCollection;
        
        public List<Pair<string, string>> GetRequests()
        {
            this.typesCollection = new List<Pair<string, string>>();

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

            //declare array of tuples
            List<Pair<string, string>> pairs = new List<Pair<string, string>>();
            

            for(int x=0; x<names.Count(); x++)
            {
                pairs.Add(new Pair<string, string>("Keepa", names.ElementAt(x)));
            }

            //add to types collection
            typesCollection = pairs;

            return this.typesCollection;
        }
    }
}
