using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using KeepaModule.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using XModule.Models;
using XModule.Services;

namespace KeepaModule.ViewModels
{
    public partial class DataGridViewModel : BindableBase
    {
        private ObservableConcurrentCollection<string> _requests;
        private ObservableConcurrentDictionary<string, string> _ApiKeys;
        private ObservableConcurrentDictionary<string, string> _ConnStrings; 
        private IKeyService service;
        private IUnityContainer container;
        private Timer aTimer;
        public string SelectedItemKey;
        public string ApiKey;

        /// <summary>
        /// The collection of available requests
        /// </summary>
        public ObservableConcurrentCollection<string> Requests
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

        public DataGridViewModel(IUnityContainer container, IKeyService service)
        {
            this.container = container;
            var req = new AvailableRequests();
            this.Requests = new ObservableConcurrentCollection<string>();
            this.Requests = req.GetRequests();
            this.service = service;
            this.ApiKeys = new ObservableConcurrentDictionary<string, string>();
            this.ConnStrings = new ObservableConcurrentDictionary<string, string>();
            this.ApiKeys = service.GetKeys();
            this.ConnStrings = service.GetConnections();
            this.UpdateServicesCommand = new DelegateCommand(UpdateServices);
            this.AddKeyToPluginCommand = new DelegateCommand(AddKeyToPlugin);
            this.aTimer = new Timer();

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
