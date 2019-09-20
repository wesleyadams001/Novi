using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace prism7.Security
{
    public static class Encryption
    {
        public static void ToggleEncryptDecrypt()
        {
            // Takes the executable file name without the
            // .config extension.
            try
            {
                //Set protected config provider
                string provider = "RsaProtectedConfigurationProvider";

                // Open the configuration file and retrieve 
                // the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

                //Get section for user settings
                ConfigurationSection userSettings = config.GetSection("userSettings/prism7.Properties.Settings");

                //Check if encrypted
                if (userSettings.SectionInformation.IsProtected)
                {
                    // Remove encryption.
                    userSettings.SectionInformation.UnprotectSection();
                    
                    // Save the current configuration file
                    config.Save();

                    //Update settings to unencrypted
                    Properties.Settings.Default.Encryption = false;

                    //Save settings
                    Properties.Settings.Default.Save();

                    //refresh previously updated properties
                    Properties.Settings.Default.Reload();

                }
                else
                {
                    //encrypt using RSA
                    userSettings.SectionInformation.ProtectSection(provider);

                    //save configuration file
                    config.Save();

                    //Update settings to unencrypted
                    Properties.Settings.Default.Encryption = true;

                    //Save settings
                    Properties.Settings.Default.Save();

                    //refresh previously updated properties
                    Properties.Settings.Default.Reload();
                } 

                //Log encryption
                Console.WriteLine("Protected={0}", userSettings.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Turn on encryption
        /// </summary>
        public static void ConfigEncryptionOn()
        {
            // Takes the executable file name without the
            // .config extension.
            try
            {
                //Set protected config provider
                string provider = "RsaProtectedConfigurationProvider";

                // Open the configuration file and retrieve 
                // the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

                //Get section for user settings
                ConfigurationSection userSettings = config.GetSection("userSettings/prism7.Properties.Settings");

                //encrypt using RSA
                userSettings.SectionInformation.ProtectSection(provider);

                //save configuration
                config.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();

                //Log encryption
                Console.WriteLine("Protected={0}", userSettings.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Turn off configuration encryption
        /// </summary>
        public static void ConfigEncryptionOff()
        {
            // Takes the executable file name without the
            // .config extension.
            try
            {

                // Open the configuration file and retrieve 
                // the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

                //Get section for user settings
                ConfigurationSection userSettings = config.GetSection("userSettings/prism7.Properties.Settings");

                //Check if encrypted
                if (userSettings.SectionInformation.IsProtected)
                {
                    // Remove encryption.
                    userSettings.SectionInformation.UnprotectSection();

                    // Save the current configuration.
                    config.Save();

                    //refresh previously updated properties
                    Properties.Settings.Default.Reload();
                }

                //Log encryption
                Console.WriteLine("Protected={0}", userSettings.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
