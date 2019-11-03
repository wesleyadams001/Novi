using Autofac;
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
        /// Command to add a key to a plugin from the list of keys available
        /// </summary>
        public DelegateCommand AddKeyToPluginCommand { get; private set; }

        /// <summary>
        /// Command to update the services manually if needed
        /// </summary>
        public DelegateCommand UpdateServicesCommand { get; private set; }


        /// <summary>
        /// Method corresponding to command to update services
        /// </summary>
        private void UpdateServices()
        {
           
            this.service = container.Resolve<IKeyService>();
            this.ApiKeys = this.service.GetKeys();
            this.ConnStrings = this.service.GetConnections();
        }

        /// <summary>
        /// Method corresponding to command to set the plugins API Key
        /// </summary>
        private void AddKeyToPlugin()
        { 
            //store selected item in the current key persistence
            Properties.Settings.Default.CurrentKey = this.SelectedItemKey;

            //Save the selected item in the key persistence
            Properties.Settings.Default.Save();

            //reload the persistene for access elsewhere
            Properties.Settings.Default.Reload();
        }

        /// <summary>
        /// Method corresponding to command to set the plugins connstring
        /// </summary>
        private void AddConnToPlugin()
        {
            //this.logger.
            Properties.Settings.Default.CurrentConnString = this.itemConnectionString;

            Properties.Settings.Default.Save();

            Properties.Settings.Default.Reload();
        }
    }
}
