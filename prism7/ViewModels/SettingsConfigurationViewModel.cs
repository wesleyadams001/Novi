﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace prism7.ViewModels
{
    /// <summary>
    /// The view model for the settings configuration
    /// </summary>
    public partial class SettingsConfigurationViewModel : BindableBase
    {
        /// <summary>
        /// Dictionary that corresponds to user input Api Keys
        /// </summary>
        public ObservableConcurrentDictionary<string, string> ApiKeys
        {
            get { return _apiKeys; }
            set { _apiKeys = value; OnPropertyChanged("ApiKeys"); }
        }

        /// <summary>
        /// Private backing field necessary to raise property changed notification
        /// </summary>
        private ObservableConcurrentDictionary<string, string> _apiKeys;


        /// <summary>
        /// Dictionary that corresponds to user input Connection Strings
        /// </summary>
        public ObservableConcurrentDictionary<string, string> ConnectionStrings
        {
            get { return _connStrings; }
            set { _connStrings = value; OnPropertyChanged("ConnectionStrings"); }
        }

        /// <summary>
        /// Private backing field of connection strings necessary to raise property changed notification
        /// </summary>
        private ObservableConcurrentDictionary<string, string> _connStrings;
        

        /// <summary>
        /// Boolean value to indicate whether to use encryption of not
        /// </summary>
        public bool UseEncryption {
            get => _useEncryption;
            set => _useEncryption = value;
        }
        private bool _useEncryption;

        /// <summary>
        /// The api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The Api it belongs to
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// The connectino string Api
        /// </summary>
        public string csApi { get; set; }

        /// <summary>
        /// The connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The Key of the selected item
        /// </summary>
        public string SelectedItemKey { get; set; }


        /// <summary>
        /// Default constructor for settings configuration view model
        /// </summary>
        public SettingsConfigurationViewModel()
        {

            //See if it has default value or not
            if (!Properties.Settings.Default.ApiKeys.Equals("empty"))
            {
                //Get Api key value
                var keys = Properties.Settings.Default.ApiKeys;

                //if not default value deserialize the dictionary
                this.ApiKeys = JsonConvert.DeserializeObject<ObservableConcurrentDictionary<string, string>>(keys);
            }
            if (!Properties.Settings.Default.ConnectionStrings.Equals("empty"))
            {
                var constrs = Properties.Settings.Default.ConnectionStrings;

                this.ConnectionStrings = JsonConvert.DeserializeObject<ObservableConcurrentDictionary<string, string>>(constrs);
            }
            this.ToggleEncryptionCommand = new DelegateCommand(ToggleEncryption);
            this.EncryptSettingsFileCommand = new DelegateCommand(EncryptUserFile);
            this.DecryptSettingsFileCommand = new DelegateCommand(DecryptUserFile);
            this.UseEncryption = Properties.Settings.Default.Encryption;
            this.AddApiKeyCommand = new DelegateCommand(AddApiKey);
            this.AddConnectionStringCommand = new DelegateCommand(AddConnectionString);
            this.RemoveApiKeyCommand = new DelegateCommand(RemoveApiKey);
            this.RemoveConnectionStringCommand = new DelegateCommand(RemoveConnectionString);
            this.SelectedItemKey = null;
        }





    }
}
