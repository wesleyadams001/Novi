using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Autofac;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using XModule.Interfaces;
using XModule.Models;
using XModule.Services;

namespace XModule
{
    /// <summary>
    /// This module acts as kind of definitions donkey
    /// </summary>
    public class XModule : Module, IModule
    {
        private const string Name = "XModule";

        private const string Description = "Module of Definition";

        public XModule()
        {

        }

        public void Initialize()
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {

        }
    }
}
