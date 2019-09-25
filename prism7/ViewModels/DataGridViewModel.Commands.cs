using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace prism7.ViewModels
{
    public partial class DataGridViewModel
    {
        /// <summary>
        /// Delegate command that adds selecte item to acive list
        /// </summary>
        public DelegateCommand AddSelectedItemToActiveCommand { get; private set; }

        /// <summary>
        /// Delegate command that removes selected item from active list
        /// </summary>
        public DelegateCommand RemoveSelectedItemFromActiveCommand { get; private set; }

        /// <summary>
        /// Delegate command that opens the parameter input dialog box
        /// </summary>
        public DelegateCommand OpenDialogInputParamsCommand { get; private set; }

        /// <summary>
        /// Method that adds selected item to active list
        /// </summary>
        private void AddSelectedItemToActive()
        {
            this.ActiveRequests.Add(this.SelectedRequestItem);
        }

        /// <summary>
        /// Method that removes selected active item from active list
        /// </summary>
        private void RemoveSelectedItemFromActive()
        {
            this.ActiveRequests.Remove(this.SelectedActiveRequestItem);
        }

        private void OpenDialogInputParams()
        {
            //Open modal
        }
    }
}
