using Microsoft.Practices.Unity;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;

namespace KeepaModule.ViewModels
{
    public partial class DataGridViewModel
    {
        /// <summary>
        /// Command to update the services
        /// </summary>
        public DelegateCommand UpdateServicesCommand { get; private set; }


        /// <summary>
        /// Method corresponding to command
        /// </summary>
        private void UpdateServices()
        {
            this.service = container.Resolve<IKeyService>();
            this.ApiKeys = this.service.GetKeys();
            this.ConnStrings = this.service.GetConnections();
        }
    }
}
