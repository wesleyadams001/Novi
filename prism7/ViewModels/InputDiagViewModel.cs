using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;
using XModule.Services;

namespace AclProcessor.ViewModels
{
    /// <summary>
    /// Input dialog box viewmodel
    /// </summary>
    public class InputDiagViewModel : BindableBase
    {
        private IActiveRequestsService service;
        public string Input { get; set; }
        private ObservableCollection<RequestObject> _dataCollection;

        public InputDiagViewModel(IActiveRequestsService service)
        {
            this.service = service;
            this.DataCollection = service.GetRequests();
        }

        public ObservableCollection<RequestObject> DataCollection
        {
            get { return _dataCollection; }
            set { _dataCollection = value; OnPropertyChanged("DataCollection"); }
        }
    }


}
