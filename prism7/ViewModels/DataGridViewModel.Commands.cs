using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XModule.Models;
using XModule.Services;
using Microsoft.Practices.Unity;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Threading;
using System.Data;
using System.Timers;

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

        public DelegateCommand EditParametersCommand { get; private set; }

        

        /// <summary>
        /// Method that adds selected item to active list
        /// </summary>
        private void AddSelectedItemToActive()
        {
            
            //if selected request item is not null
            if(this.SelectedRequestItem != null)
            {
                //Add to obs collection
                this.ActiveRequests.Add(this.SelectedRequestItem);

                //serialize and add to persist
                var strObj = JsonConvert.SerializeObject(this.SelectedRequestItem);
                Properties.Settings.Default.ActiveRequests.Add(strObj);

                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();
               
                
            }
            

        }

        /// <summary>
        /// Method that allows the editing of request parameters
        /// </summary>
        private void EditParameters()
        {
            this.ParameterList.Clear();

            for(int x =0; x< this.SelectedActiveRequestItem.ParameterList.Count; x++)
            {
                this.ParameterList.Add(this.SelectedActiveRequestItem.ParameterList.ElementAt(x));
            }
            
        }

        /// <summary>
        /// Method that removes selected active item from active list
        /// </summary>
        private void RemoveSelectedItemFromActive()
        {
           //if not null
            if(this.SelectedActiveRequestItem != null)
            {
                //Remove item from observable list
                this.ActiveRequests.Remove(this.SelectedActiveRequestItem);

                //Remove it from persist
                var strObj = JsonConvert.SerializeObject(this.SelectedRequestItem);
                Properties.Settings.Default.ActiveRequests.Remove(strObj);

                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();
            }
        }

       
    }
}
