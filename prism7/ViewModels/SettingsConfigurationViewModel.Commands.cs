using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using prism7.Security;
using System.Collections.Concurrent;
using System.Windows;

namespace prism7.ViewModels
{
    public partial class SettingsConfigurationViewModel
    {
        /// <summary>
        /// Toggles the encryption option
        /// </summary>
        public DelegateCommand ToggleEncryptionCommand { get; private set; }

        /// <summary>
        /// Encrypt the user settings file
        /// </summary>
        public DelegateCommand EncryptSettingsFileCommand { get; private set; }

        /// <summary>
        /// Decrypts the user settings file
        /// </summary>
        public DelegateCommand DecryptSettingsFileCommand { get; private set; }

        /// <summary>
        /// Remove Api key
        /// </summary>
        public DelegateCommand RemoveApiKeyCommand { get; private set; }

        /// <summary>
        /// Removes a connection string entry
        /// </summary>
        public DelegateCommand RemoveConnectionStringCommand { get; private set; }

        /// <summary>
        /// Add Api key command
        /// </summary>
        public DelegateCommand AddApiKeyCommand { get; private set; }

        /// <summary>
        /// Add connection string command
        /// </summary>
        public DelegateCommand AddConnectionStringCommand { get; private set; }

        /// <summary>
        /// Method that accesses the security class to toggle the encryption of 
        /// user settings file 
        /// </summary>
        private void ToggleEncryption()
        {
            Encryption.ToggleEncryptDecrypt();
        }

        /// <summary>
        /// Method that accesses the security class to turn encryption of 
        /// user settings file on
        /// </summary>
        private void EncryptUserFile()
        {
            Encryption.ConfigEncryptionOn();
        }

        /// <summary>
        /// Method that access the security class to turn encryption of 
        /// user settings file off
        /// </summary>
        private void DecryptUserFile()
        {
            Encryption.ConfigEncryptionOff();
        }

        /// <summary>
        /// Adds an api key to the users list of connection strings
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddApiKey()
        {

            //Get Api key value
            var keys = Properties.Settings.Default.ApiKeys;

            //See if it has default value or not
            if (!Properties.Settings.Default.ApiKeys.Equals("empty"))
            {
                //if not default value deserialize the dictionary
                this.ApiKeys = JsonConvert.DeserializeObject<ObservableConcurrentDictionary<string, string>>(keys);
            }
            else
            {
                //otherwise create a dictionary
                this.ApiKeys = new ObservableConcurrentDictionary<string, string>();
            }

            try
            {
                //Add item to dictionary
               this.ApiKeys.Add(this.Api, this.ApiKey);
              
               
            }
            catch (Exception e)
            {
                //log errors
                var str = "Failed to add with following error: " + e.Message;
                MessageBoxResult result = MessageBox.Show(str,"Error",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Error);
               
            }
            finally
            {
                //Serialize a string dictionary to a json string 
                var objString = JsonConvert.SerializeObject(ApiKeys);

                //Add string to the setting apikeys
                Properties.Settings.Default.ApiKeys = objString;

                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();

            }
            

        }

        /// <summary>
        /// Removes an api key from the api key dictionary 
        /// </summary>
        /// <param name="key"></param>
        private void RemoveApiKey()
        {

            //See if it has default value or not
            if (!Properties.Settings.Default.ApiKeys.Equals("empty"))
            {
                if(this.SelectedItemKey == null)
                {
                    MessageBox.Show("No Keys to remove");
                }
                else
                {
                    //remove a target entry from the dictionary
                    int index1 = this.SelectedItemKey.IndexOf('[') + 1;
                    int index2 = this.SelectedItemKey.IndexOf(',');
                    int length = index2 - index1;
                    var key = this.SelectedItemKey.Substring(index1, length);
                    this.ApiKeys.Remove(key);

                    //Serialize a string dictionary to a json string 
                    var objString = JsonConvert.SerializeObject(ApiKeys);

                    //Add string to the setting apikeys
                    Properties.Settings.Default.ApiKeys = objString;

                    //save properties
                    Properties.Settings.Default.Save();

                    //refresh previously updated properties
                    Properties.Settings.Default.Reload();
                }
                
            }
           
        }

        /// <summary>
        /// Adds a connection string to the users list of connection strings
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddConnectionString()
        {

            //Get Api key value
            var connStrings = Properties.Settings.Default.ConnectionStrings;

            //See if it has default value or not
            if (!Properties.Settings.Default.ConnectionStrings.Equals("empty"))
            {
                //if not default value deserialize the dictionary
                this.ConnectionStrings = JsonConvert.DeserializeObject<ObservableConcurrentDictionary<string, string>>(connStrings);
            }
            else
            {
                //otherwise create a dictionary
                this.ConnectionStrings = new ObservableConcurrentDictionary<string, string>();

            }

            try
            {
                //Add item to dictionary
                this.ConnectionStrings.Add(this.Api, this.ConnectionString);
            }
            catch (Exception e)
            {
                //log errors
                Console.WriteLine("Failed to add: " + e.Message);
            }
            finally
            {
                //Serialize a string dictionary to a json string 
                var objString = JsonConvert.SerializeObject(ConnectionStrings);

                //Add string to the setting apikeys
                Properties.Settings.Default.ConnectionStrings = objString;

                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();

            }
        }

        /// <summary>
        /// Removes a Connection String from the connection string dictionary
        /// </summary>
        /// <param name="key"></param>
        private void RemoveConnectionString()
        {

            //See if it has default value or not
            if (!Properties.Settings.Default.ConnectionStrings.Equals("empty"))
            {
                if (this.SelectedItemKey == null)
                {
                    MessageBox.Show("No connection string to remove");
                }
                else
                {
                    //remove a target entry from the dictionary
                    int index1 = this.SelectedItemKey.IndexOf('[') + 1;
                    int index2 = this.SelectedItemKey.IndexOf(',');
                    int length = index2 - index1;
                    var key = this.SelectedItemKey.Substring(index1, length);
                    this.ConnectionStrings.Remove(key);

                    //Serialize a string dictionary to a json string 
                    var objString = JsonConvert.SerializeObject(ConnectionStrings);

                    //Add string to the setting apikeys
                    Properties.Settings.Default.ConnectionStrings = objString;

                    //save properties
                    Properties.Settings.Default.Save();

                    //refresh previously updated properties
                    Properties.Settings.Default.Reload();
                }
                
            }
        }
    }
}
