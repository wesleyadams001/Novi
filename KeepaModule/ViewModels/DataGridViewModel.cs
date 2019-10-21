using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using KeepaModule.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using XModule.Events;
using XModule.Models;
using XModule.Services;
using XModule.Tools;

namespace KeepaModule.ViewModels
{
    public partial class DataGridViewModel : BindableBase
    {
        private ObservableCollection<RequestObject> _requests;
        private ObservableConcurrentDictionary<string, string> _ApiKeys;
        private ObservableConcurrentDictionary<string, string> _ConnStrings; 
        private IKeyService service;
        private IUnityContainer container;
        private IEventAggregator ea;
        private Timer aTimer;
        private string itemConnectionString;
        private string itemKey;

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
                ea.GetEvent<AddKeepaKeyEvent>().Publish(itemKey);
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
                ea.GetEvent<AddKeepaConnEvent>().Publish(itemConnectionString);
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

        public DataGridViewModel(IUnityContainer container, IKeyService service, IEventAggregator eventAggregator)
        {
            this.ea = eventAggregator;
            this.container = container;
            var req = new AvailableRequests();
            this.Requests = new ObservableCollection<RequestObject>(req.GetRequests());
            this.service = service;
            this.ApiKeys = new ObservableConcurrentDictionary<string, string>();
            this.ConnStrings = new ObservableConcurrentDictionary<string, string>();
            this.ApiKeys = service.GetKeys();
            this.ConnStrings = service.GetConnections();
            this.UpdateServicesCommand = new DelegateCommand(UpdateServices);
            this.AddKeyToPluginCommand = new DelegateCommand(AddKeyToPlugin);
            this.aTimer = new Timer();
            this.SelectedItemKey = Properties.Settings.Default.CurrentKey;
            this.SelectedConnString = Properties.Settings.Default.CurrentConnString;

            //subsccribes to the add keepa key event
            this.ea.GetEvent<AddKeepaKeyEvent>().Subscribe((oc) =>
            {
                AddKeyToPlugin();
            });

            //subscribes to the add keepa conn event
            this.ea.GetEvent<AddKeepaConnEvent>().Subscribe((oc) =>
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
