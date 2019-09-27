using Prism.Mvvm;
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
        public bool UseEncryption { get; set; }

        public ObservableCollection<string> AvailableApis
        {
            get { return _availableApis; }
            set { _availableApis = value; OnPropertyChanged("AvailableApis"); }
        }

        /// <summary>
        /// The api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The Api it belongs to
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// The connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The Key of the selected item
        /// </summary>
        public string SelectedItemKey { get; set; }

        /// <summary>
        /// List of availble Apis based on loaded modules
        /// </summary>
        private ObservableCollection<string> _availableApis;

        /// <summary>
        /// Default constructor for settings configuration view model
        /// </summary>
        public SettingsConfigurationViewModel()
        {
            //set new collection 
            this.AvailableApis = new ObservableCollection<string>();

            //pull arr of strings out of properties xml
            string[] arr = new string[Properties.Settings.Default.Modules.Count];
            Properties.Settings.Default.Modules.CopyTo(arr,0);

            //add each item in the string array to list of available Apis
            for(int x = 0; x<arr.Length; x++)
            {
                AvailableApis.Add(arr[x]);
            }

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

            // Open the configuration file and retrieve 
            // the connectionStrings section.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

            //Get section for user settings
            ConfigurationSection userSettings = config.GetSection("userSettings/prism7.Properties.Settings");

            //Sets the start up value of the check boxes isChecked value based on the encryption status of the settings file
            if (userSettings.SectionInformation.IsProtected)
            {
                this.UseEncryption = true;
            }
            else
            {
                this.UseEncryption = false;
            }
        }





    }
}
