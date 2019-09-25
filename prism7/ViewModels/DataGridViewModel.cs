using System.Collections.ObjectModel;
using Prism.Mvvm;
using XModule.Models;
using XModule.Services;
using XModule.Tools;
using Prism.Commands;

namespace prism7.ViewModels
{
    /// <summary>
    /// The main DataGridViewModel that manages the logic for the main panel
    /// </summary>
    public partial class DataGridViewModel : BindableBase
    {
        private ObservableCollection<Pair<string, string>> requests;
        private ObservableCollection<Pair<string, string>> activerequests;

        /// <summary>
        /// indicates if the request is active
        /// </summary>
        public bool isActive;

        /// <summary>
        /// The currently selected request item
        /// </summary>
        public Pair<string, string> SelectedRequestItem { get; set; }
        
        /// <summary>
        /// The currently selected active request item
        /// </summary>
        public Pair<string, string> SelectedActiveRequestItem { get; set; }

        /// <summary>
        /// List of available requests
        /// </summary>
        public ObservableCollection<Pair<string, string>> Requests
        {
            get { return requests; }
            set { SetProperty(ref requests, value); }
        }

        /// <summary>
        /// List of active requests
        /// </summary>
        public ObservableCollection<Pair<string,string>> ActiveRequests
        {
            get { return activerequests; }
            set { SetProperty(ref activerequests, value); }
        }

        /// <summary>
        /// Constructor that takes an instance of AvailableRequestsService
        /// </summary>
        /// <param name="service"></param>
        public DataGridViewModel(IAvailableRequestsService service)
        {
            this.Requests = new ObservableCollection<Pair<string, string>>();
            this.ActiveRequests = new ObservableCollection<Pair<string, string>>();
            this.AddSelectedItemToActiveCommand = new DelegateCommand(AddSelectedItemToActive);
            this.RemoveSelectedItemFromActiveCommand = new DelegateCommand(RemoveSelectedItemFromActive);
            this.SelectedRequestItem = new Pair<string, string>("","");
            this.SelectedActiveRequestItem = new Pair<string, string>("", "");
            this.Requests.AddRange(service.GetRequests());
        }
    }
}
