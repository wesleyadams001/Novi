using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using System.Configuration;
using System.Xml.Linq;
using XModule.Models;
using Newtonsoft.Json;

namespace Service
{
    /// <summary>
    /// The base of the Novi Service that inherits from Service Base class 
    /// </summary>
    public partial class NoviService : ServiceBase, IModule
    {
        private Pipe ServicePipeline { get; set; }
        private ContainerBuilder builder { get; set; }
        private Autofac.IContainer container { get; set; }
        private string configPath;
        private string currentXml;
        private XDocument doc;
        private List<RequestObject> ActiveRequests;

        public NoviService()
        {
            InitializeComponent();

            //On construction create event log
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("NoviServiceSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "NoviServiceSource", "NoviServiceLog");
            }
            eventLog1.Source = "NoviServiceSource";
            eventLog1.Log = "NoviServiceLog";
            
         
        }

        protected override void OnStart(string[] args)
        {
            //Configure the service
            eventLog1.WriteEntry("Configure Novi Service");
            Configure();

            //Read in request objects from Active Requests File
            eventLog1.WriteEntry("Parse out request objects");
            var requestObjects = ParseConfigFile(this.configPath);

            //Post to the pipeline
            foreach(RequestObject ro in requestObjects)
            {
                //post request objects
                this.ServicePipeline.Post(ro);
            }


        }

        protected override void OnStop()
        {
        }

        public void Configure()
        {
            //set up a new containerBuilder
            this.builder = new ContainerBuilder();

            //get the path of the executing assemblies and navigate to the modules folder
            var pathOfAsm = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetDirectoryName(pathOfAsm) + "\\Debug\\modules";
            this.eventLog1.WriteEntry("The target path is: " + path);

            if (String.IsNullOrWhiteSpace(path))
            {
                return;
            }

            //  Gets all compiled assemblies.
            var assemblies = Directory.GetFiles(path, "*Module.dll", SearchOption.AllDirectories).Select(Assembly.LoadFrom).Where(x => !x.FullName.StartsWith("X"));


            foreach (var assembly in assemblies)
            {
                //  Gets the all modules from each assembly to be registered.
                //  Make sure that each module **MUST** have a parameterless constructor.
                var modules = assembly.GetTypes()
                                      .Where(p => typeof(IModule).IsAssignableFrom(p)
                                                  && !p.IsAbstract)
                                      .Select(p => (IModule)Activator.CreateInstance(p));

                //  Regsiters each module.
                foreach (var module in modules)
                {
                    builder.RegisterModule(module);

                }
            }

            //build to a IContainer
            var container = this.builder.Build();

            //set config path
            this.configPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            this.eventLog1.WriteEntry("The config path is: " + configPath);
            
            //set up a new pipe
            this.ServicePipeline = new Pipe(container);
            
        }

        private RequestObject[] ParseConfigFile(string path)
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
            for (int x = 0; x< arrNames.Length; x++)
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

        public void Configure(IComponentRegistry componentRegistry)
        {
            
        }
    }
}
