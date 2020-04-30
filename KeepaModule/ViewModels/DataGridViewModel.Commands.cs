using Autofac;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;

namespace NtfsModule.ViewModels
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
        /// Command to ping the database using the CheckConnection method
        /// </summary>
        public DelegateCommand PingDatabaseCommand { get; private set; }

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

        /// <summary>
        /// Checks a connection to the current modules target connection string
        /// </summary>
        private void CheckConnection()
        {
            try
            {
                var str = Properties.Settings.Default.CurrentConnString;
                this.logger.Debug("Connecting to: " + str);
                using (var connection = new SqlConnection(str))
                {
                    var query = "select 1";
                    this.logger.Debug("Executing: " + query);

                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    this.logger.Debug("SQL Connection successful.");

                    command.ExecuteScalar();
                    this.logger.Debug("SQL Query execution successful.");

                    this.Validity = true;
                }
            }
            catch (Exception ex)
            {
                this.logger.Debug("Failure: " + ex.Message);
                this.Validity = false;
            }
        }
    }
}
