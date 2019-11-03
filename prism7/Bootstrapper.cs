using FirstFloor.ModernUI.Presentation;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using XModule.Interfaces;
using Newtonsoft.Json;
using XModule.Services;
using prism7.Services;
using Prism.Events;
using prism7.Factory;
using System.IO;
using Prism.Autofac;
using Autofac;
using Autofac.Core;
using IModule = Autofac.Core.IModule;

namespace prism7
{

    class Bootstrapper : AutofacBootstrapper
    {
        private const string MODULES_PATH = @".\modules";
        private LinkGroupCollection linkGroupCollection = null;
        public static ContainerBuilder Builder = null;

        protected override DependencyObject CreateShell()
        {
            Shell shell = Container.Resolve<Shell>();

            if (linkGroupCollection != null)
            {
                shell.AddLinkGroups(linkGroupCollection);

                //Clear out any previous modules as they might have changed
                Properties.Settings.Default.Modules.Clear();

                //load available modules
                foreach (LinkGroup temp in linkGroupCollection)
                {
                    Properties.Settings.Default.Modules.Add(temp.DisplayName);
                }
            }

            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            base.ConfigureContainerBuilder(builder);
            builder.RegisterType<KeyService>().As<IKeyService>();
            builder.RegisterType<ActiveRequestsService>().As<IActiveRequestsService>();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>();
            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();

            var pathOfAsm = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.GetDirectoryName(pathOfAsm) + "\\Debug\\modules";

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
            Builder = builder;
        }
        

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = MODULES_PATH };
        }

        protected override void ConfigureModuleCatalog()
        {
            // Dynamic Modules are copied to a directory as part of a post-build step.
            // These modules are not referenced in the startup project and are discovered 
            // by examining the assemblies in a directory. The module projects have the 
            // following post-build step in order to copy themselves into that directory:
            //
            // xcopy "$(TargetDir)$(TargetFileName)" "$(TargetDir)modules\" /y
            //
            // Explicitly compile the solution before each running
            // so the modules are copied into the modules folder.
            var directoryCatalog = (DirectoryModuleCatalog)ModuleCatalog;
            directoryCatalog.Initialize();

            linkGroupCollection = new LinkGroupCollection();
            var typeFilter = new TypeFilter(InterfaceFilter);

            foreach (var module in directoryCatalog.Items)
            {
                var mi = (ModuleInfo)module;
                var asm = Assembly.LoadFrom(mi.Ref);

                foreach (Type t in asm.GetTypes())
                {
                    var myInterfaces = t.FindInterfaces(typeFilter, typeof(ILinkGroupService).ToString());

                    if (myInterfaces.Length > 0)
                    {
                        // We found the type that implements the ILinkGroupService interface
                        var linkGroupService = (ILinkGroupService)asm.CreateInstance(t.FullName);
                        var linkGroup = linkGroupService.GetLinkGroup();
                        linkGroupCollection.Add(linkGroup);
                    }
                }

                
            }

            // The XModule is defined in the code so as to always be loaded
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(XModule.XModule));
        }

        private bool InterfaceFilter(Type typeObj, Object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }

    }
}
