﻿using System.Collections.ObjectModel;
using Prism.Mvvm;
using XModule.Models;
using XModule.Services;
using XModule.Tools;
using Prism.Commands;
using Microsoft.Practices.Unity;
using System.Data;
using System.Timers;
using Prism.Events;
using XModule.Events;

namespace prism7.ViewModels
{
    /// <summary>
    /// The main DataGridViewModel that manages the logic for the main panel
    /// </summary>
    public partial class DataGridViewModel : BindableBase
    {
        private IEventAggregator ea;
        private ObservableCollection<RequestObject> requests;
        private ObservableCollection<RequestObject> activerequests;
        private IUnityContainer container;
        private ObservableCollection<Pair<string, object>> parameters;

        /// <summary>
        /// indicates if the request is active
        /// </summary>
        public bool isActive;

        /// <summary>
        /// The currently selected request item
        /// </summary>
        public RequestObject SelectedRequestItem { get; set; }
        
        /// <summary>
        /// The currently selected active request item
        /// </summary>
        public RequestObject SelectedActiveRequestItem { get; set; }

        /// <summary>
        /// List of available requests
        /// </summary>
        public ObservableCollection<RequestObject> Requests
        {
            get { return requests; }
            set { SetProperty(ref requests, value); }
        }

        /// <summary>
        /// List of active requests
        /// </summary>
        public ObservableCollection<RequestObject> ActiveRequests
        {
            get { return activerequests; }
            set
            {
                SetProperty(ref activerequests, value);
            }
        }

        /// <summary>
        /// List of Parameters
        /// </summary>
        public ObservableCollection<Pair<string,object>> ParameterList
        {
            get { return parameters; }
            set { SetProperty(ref parameters, value); }
        }

        /// <summary>
        /// Constructor that takes an instance of AvailableRequestsService
        /// </summary>
        /// <param name="service"></param>
        public DataGridViewModel(IUnityContainer container, IAvailableRequestsService service, IActiveRequestsService activeReqService, IEventAggregator aggregator)
        {
            this.ea = aggregator;
            this.container = container;
            this.Requests = new ObservableCollection<RequestObject>(service.GetRequests());
            this.ActiveRequests = new ObservableCollection<RequestObject>();
            this.ActiveRequests = activeReqService.GetRequests();
            this.AddSelectedItemToActiveCommand = new DelegateCommand(AddSelectedItemToActive);
            this.RemoveSelectedItemFromActiveCommand = new DelegateCommand(RemoveSelectedItemFromActive);
            this.SelectedRequestItem = new RequestObject();
            this.SelectedActiveRequestItem = new RequestObject();
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
            this.EditParametersCommand = new DelegateCommand(EditParameters);
            this.SaveParametersCommand = new DelegateCommand(SaveParameters);
        }

        
    }
}
