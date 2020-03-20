using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;

namespace parserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            parse();
        }

        private static void parse()
        {
            //load XDocument from path
            this.doc = XDocument.Load(path);

            //Parse out array strings
            var arrNames = this.doc.Root
                .Descendants("ArrayOfString")
                .Select(e => e.Attribute("string").Value.ToString()).ToArray();

            //Create array of requestobjects
            RequestObject[] requests = new RequestObject[arrNames.Length];

            //deserialize json strings to request objects and fill array
            for (int x = 0; x < arrNames.Length; x++)
            {
                RequestObject ro = null;

                eventLog1.WriteEntry(arrNames[x].ToString());

                try
                {
                    ro = JsonConvert.DeserializeObject<RequestObject>(arrNames[x]);

                }
                catch (Exception e)
                {
                    eventLog1.WriteEntry(e.Message);
                }

                requests[x] = ro;
            }

            //return the current set of active request objects
            return requests;
        }
    }
}
