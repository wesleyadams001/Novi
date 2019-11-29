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
using XModule.Models;
using System.IO;
using XModule;
using static XModule.Constants.Enums;

namespace KeepaModule.Services
{
    public class AvailableRequests : IAvailableRequestsService
    {
        private const RequestTypes ModuleName = RequestTypes.Keepa;
        private RequestObject[] typesCollection;

        public RequestObject[] GetRequests()
        {

            //Use parent type as a root
            Type parentType = typeof(KeepaRequest);

            //Look at current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Get associated types
            Type[] types = assembly.GetTypes();

            //Get subclasses
            var subclasses = types.Where(t => t.IsSubclassOf(parentType));

            //Gets methods
            var methods = subclasses.SelectMany(x => x.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)).Where(y => y.GetCustomAttributes(typeof(Tag), false).Length > 0).ToArray();

            //Gets the names
            var mNames = methods.Select(t => t.Name);

            //declare array of tuples
            RequestObject[] requestObjects = new RequestObject[methods.Count()];

            for (int x = 0; x < methods.Length; x++)
            {
                //Something
                requestObjects[x] = new RequestObject(mNames.ElementAt(x), ModuleName);

                //Method information
                var methodInfo = methods[x];

                //Get method parameters
                var val = methodInfo.GetParameters();

                //Get strings of parameters
                var j = val.Select(o => o.ParameterType.Name.ToString());

                for (int z = 0; z < j.Count(); z++)
                {
                    //assign strings to parameter list
                    requestObjects[x].ParameterList.Add(new Pair<string, object>(j.ElementAt(z), string.Empty));
                    
                }

            }


            //add to types collection
            typesCollection = requestObjects;

            return this.typesCollection;
        }

        private void WriteToFile(string text)
        {
            //File.WriteAllText(@"D:\Wesley\Documents\", text +".txt");
            File.AppendAllText(@"D:\Wesley\Documents\Test.txt", text + "\n");
        }
    }
}
