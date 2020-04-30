using System.Collections.ObjectModel;
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
using XModule.Interfaces;
using Prism.Autofac;
using Autofac;
using AclProcessor.Models;
using System;
using static XModule.Constants.Enums;

namespace AclProcessor.ViewModels
{
    /// <summary>
    /// The main DataGridViewModel that manages the logic for the main panel
    /// </summary>
    public partial class DataGridViewModel : BindableBase
    {
        private ILogger logger;
        private IEventAggregator ea;
        private ObservableCollection<MenuItem> requests;
        private ObservableCollection<RequestObject> activerequests;
        private IComponentContext container;
        private ObservableCollection<Pair<string, object>> parameters;
        private ObservableCollection<Pair<string, object>> activeRequestParameterList;
        private string selectedRequestRootName;
        private string selectedRequestItemName;
        private MenuItem selectedMenuItemObject;

        /// <summary>
        /// indicates if the request is active
        /// </summary>
        public bool isActive;

        /// <summary>
        /// Selected Menu Item object
        /// </summary>
        public MenuItem SelectedMenuItemObject
        {
            get { return selectedMenuItemObject; }
            set
            {
                SetProperty(ref selectedMenuItemObject, value);

                if (selectedMenuItemObject != null)
                {
                    ea.GetEvent<SelectedMenuItemChangedEvent>().Publish(selectedMenuItemObject);

                }
            }
        }

        /// <summary>
        /// The currently selected request item
        /// </summary>
        public string SelectedRequestItemName 
        {
            get { return selectedRequestItemName; } 
            set
            {
                SetProperty(ref selectedRequestItemName, value);

               
            }
        }
        
        /// <summary>
        /// The currently selected request item root
        /// </summary>
        public string SelectedRequestRootName 
        {
            get { return selectedRequestRootName; }
            set {
                SetProperty(ref selectedRequestRootName, value);

                
            } 
        }

        /// <summary>
        /// The current request object 
        /// </summary>
        public RequestObject SelectedRequestItem { get; set; }

        /// <summary>
        /// The currently selected active request item
        /// </summary>
        public RequestObject SelectedActiveRequestItem { get; set; }

        /// <summary>
        /// List of available requests
        /// </summary>
        public ObservableCollection<MenuItem> Requests
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
        /// List of selected Active request parameters
        /// </summary>
        public ObservableCollection<Pair<string, object>> SelectedActiveRequestParameterList
        {
            get { return activeRequestParameterList; }
            set { SetProperty(ref activeRequestParameterList, value); }
        }

        /// <summary>
        /// Constructor that takes an instance of AvailableRequestsService
        /// </summary>
        /// <param name="service"></param>
        public DataGridViewModel(IComponentContext container, IAvailableRequestsService service, IActiveRequestsService activeReqService, IEventAggregator aggregator, ILoggerFactory logFactory)
        {
            this.logger = logFactory.Create<DataGridViewModel>(); 
            logger.Debug("Initialized " + typeof(DataGridViewModel));

            this.ea = aggregator;
            this.container = container;
            this.Requests = new ObservableCollection<MenuItem>();
            this.Requests.AddRange(CreateMenuItems());

            this.ActiveRequests = new ObservableCollection<RequestObject>();
            this.ActiveRequests = activeReqService.GetRequests();
            this.AddSelectedItemToActiveCommand = new DelegateCommand(AddSelectedItemToActive);
            this.RemoveSelectedItemFromActiveCommand = new DelegateCommand(RemoveSelectedItemFromActive);
            this.SelectedRequestItem = new RequestObject();
            this.SelectedActiveRequestItem = new RequestObject();
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
            this.SelectedActiveRequestParameterList = new ObservableCollection<Pair<string, object>>();
            this.EditParametersCommand = new DelegateCommand(EditParameters);
            this.SaveParametersCommand = new DelegateCommand(SaveParameters);

            this.ea.GetEvent<SelectedMenuItemChangedEvent>().Subscribe((item) =>
            {
                //once clicked parse out the appropriate menu item properties (api name & request name)
                Enum.TryParse(item.Title, out RequestTypes result);
                this.SelectedRequestItem.ApiName = result;
                this.SelectedRequestItem.RequestName = item.Title;

                //remove any previous parameters
                this.SelectedRequestItem.ParameterList.Clear();

                //add the menu items parameter list to the selected request items parameter list
                this.SelectedRequestItem.ParameterList.AddRange(item.ParameterList);
               
                
            });

            
        }

        
    }
}
