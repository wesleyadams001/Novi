using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using NtfsModule.Services;
using Autofac;
using Autofac.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using XModule.Events;
using XModule.Models;
using XModule.Services;
using XModule.Tools;
using XModule.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NtfsModule.ViewModels
{
    public partial class DataGridViewModel : BindableBase
    {
        private ObservableCollection<RequestObject> _requests;
        private ObservableConcurrentDictionary<string, string> _ApiKeys;
        private ObservableConcurrentDictionary<string, string> _ConnStrings; 
        private IKeyService service;
        private IComponentContext container;
        private IEventAggregator ea;
        private ILogger logger;
        private Timer aTimer;
        private string itemConnectionString;
        private string itemKey;
        private bool validity;
        private string imagepath;
        private ResourceDictionary dictionary;

        /// <summary>
        /// The current connection image path
        /// </summary>
        public string ImagePath
        {
            get { return imagepath; }
            set
            {
                SetProperty(ref imagepath, value);
            }
        }

        /// <summary>
        /// The validity of the current connection string
        /// </summary>
        public bool Validity { 
            get { return validity; }
            set
            {
                SetProperty(ref validity, value);

                ea.GetEvent<ConnectionImageChanged>().Publish(validity);
            }
        }

        /// <summary>
        /// The currently selected Api key
        /// </summary>
        public string SelectedItemKey {
            get { return itemKey; }
            set
            {

                //set property and fire property changed event
                SetProperty(ref itemKey, value);

                //publish event
                ea.GetEvent<AddNtfsKeyEvent>().Publish(itemKey);
            }
        }

        /// <summary>
        /// The currently selected connection string
        /// </summary>
        public string SelectedConnString
        {
            get { return itemConnectionString; }
            set
            {
                //set property and fire property changed event
                SetProperty(ref itemConnectionString, value);

                //publish event
                ea.GetEvent<AddNtfsConnEvent>().Publish(itemConnectionString);
            }
        }

        /// <summary>
        /// The collection of available requests
        /// </summary>
        public ObservableCollection<RequestObject> Requests
        {
            get { return _requests; }
            set { SetProperty(ref _requests, value); OnPropertyChanged("Requests"); }
        }

        /// <summary>
        /// Observable collection of api keys
        /// </summary>
        public ObservableConcurrentDictionary<string, string> ApiKeys
        {
            get { return _ApiKeys; }
            set { SetProperty(ref _ApiKeys, value); OnPropertyChanged("ApiKeys"); }
        }

        /// <summary>
        /// Observable collection of connection strings
        /// </summary>
        public ObservableConcurrentDictionary<string, string> ConnStrings
        {
            get { return _ConnStrings; }
            set { SetProperty(ref _ConnStrings, value); OnPropertyChanged("ConnStrings"); }
        }

        public DataGridViewModel(IComponentContext container, IKeyService service, IEventAggregator eventAggregator, ILoggerFactory loggerfac)
        {
            this.ea = eventAggregator;
            this.container = container;
            this.logger = loggerfac.Create<DataGridViewModel>();
            var req = new AvailableRequests();
            this.Requests = new ObservableCollection<RequestObject>(req.GetRequests());
            this.service = service;
            this.ApiKeys = new ObservableConcurrentDictionary<string, string>();
            this.ConnStrings = new ObservableConcurrentDictionary<string, string>();
            this.ApiKeys = service.GetKeys();
            this.ConnStrings = service.GetConnections();
            this.UpdateServicesCommand = new DelegateCommand(UpdateServices);
            this.AddKeyToPluginCommand = new DelegateCommand(AddKeyToPlugin);
            this.PingDatabaseCommand = new DelegateCommand(CheckConnection);
            this.aTimer = new Timer();
            this.SelectedItemKey = Properties.Settings.Default.CurrentKey;
            this.SelectedConnString = Properties.Settings.Default.CurrentConnString;
            this.Validity = false;

            this.dictionary = new ResourceDictionary();
            this.dictionary.Source = new Uri("/XModule;component/Resources/ResourceDictionary.xaml", UriKind.RelativeOrAbsolute);
            var value = this.dictionary["idatabackup50"].ToString();
            this.ImagePath = this.dictionary["idatabackup50"].ToString();
            
            this.ea.GetEvent<ConnectionImageChanged>().Subscribe((oc) =>
            {
                if (oc)
                {
                    this.ImagePath = this.dictionary["idatabaseview50"].ToString();
                }
                else
                {
                    this.ImagePath = this.dictionary["ideletedatabase50"].ToString();
                }
            });

            //subsccribes to the add Ntfs key event
            this.ea.GetEvent<AddNtfsKeyEvent>().Subscribe((oc) =>
            {
                AddKeyToPlugin();
            });

            //subscribes to the add Ntfs conn event
            this.ea.GetEvent<AddNtfsConnEvent>().Subscribe((oc) =>
            {
                AddConnToPlugin();
            });

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 500;
            aTimer.Enabled = true;

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            UpdateServices();
        }


    }
}
