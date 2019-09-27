using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Models;

namespace prism7.ViewModels
{
    /// <summary>
    /// Input dialog box viewmodel
    /// </summary>
    public class InputDiagViewModel : BindableBase
    {
        public string Input { get; set; }
        private ObservableCollection<RequestObject> _dataCollection;

        public ObservableCollection<RequestObject> DataCollection
        {
            get { return _dataCollection; }
            set { _dataCollection = value; OnPropertyChanged("DataCollection"); }
        }
    }
}
