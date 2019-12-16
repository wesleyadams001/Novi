using Newtonsoft.Json;
using Prism.Commands;
using Prism.Autofac;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XModule.Models;
using XModule.Services;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Threading;
using System.Data;
using System.Timers;
using XModule.Events;
using prism7.Models;
using System.Collections.ObjectModel;

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
        /// Delegate command that points at the edit parameters method
        /// </summary>
        public DelegateCommand EditParametersCommand { get; private set; }

        /// <summary>
        /// Save command that points at the save parameters method
        /// </summary>
        public DelegateCommand SaveParametersCommand { get; private set; }

        /// <summary>
        /// Method that adds selected item to active list
        /// </summary>
        private void AddSelectedItemToActive()
        {
            
            //if selected request item is not null
            if(this.SelectedRequestItem != null && (this.SelectedRequestItem.RequestName.Equals(this.SelectedRequestItem.ApiName.ToString())==false))
            {
                //Add to obs collection
                this.ActiveRequests.Add(this.SelectedRequestItem);

                //publish event
                this.ea.GetEvent<CollectionChangedEvent>().Publish(this.SelectedRequestItem);
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
        /// Method to save parameters to persist
        /// </summary>
        private void SaveParameters()
        {
            if(this.SelectedActiveRequestItem != null)
            {
                //serialize and add to persist
                var strObj = JsonConvert.SerializeObject(this.SelectedActiveRequestItem);
                Properties.Settings.Default.ActiveRequests.Add(strObj);
                
                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();

            }
           
        }

        /// <summary>
        /// Creates DataGrid menu items that populate the tree view
        /// </summary>
        /// <returns></returns>
        private List<MenuItem> CreateMenuItems()
        {
            //Create menu items
            List<MenuItem> MenuItems = new List<MenuItem>();

            //Resolve Request Services
            var availableRequests = this.container.Resolve<IEnumerable<IAvailableRequestsService>>();
            for(int x = 0; x< availableRequests.Count(); x++)
            {
                //Gets associated requests in each service
                var RequestObjects = availableRequests.ElementAt(x).GetRequests();
                string[] namesArr = new string[RequestObjects.Length];
                MenuItem item = new MenuItem(RequestObjects[0].ApiName.ToString(), "Root");

                //Add a new Request for each item that is retrieved in the getRequests() method
                for(int y = 0; y< RequestObjects.Length; y++)
                {
                    MenuItem subItem = new MenuItem(RequestObjects.ElementAt(y).RequestName, RequestObjects[0].ApiName.ToString());

                    int size = RequestObjects[y].ParameterList.Count();

                    //Fill parameters of subitem
                    for (int z=0; z<size; z++)
                    {
                        //Add each requestObjects parameter pair to the menu item
                        subItem.ParameterList.Add(RequestObjects[y].ParameterList.ElementAt(z));
                    }

                    //Add the subitem
                    item.Items.Add(subItem);
                }

                //Add the new root to the menu
                MenuItems.Add(item);
            }
            return MenuItems;
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
                var strObj = JsonConvert.SerializeObject(this.SelectedActiveRequestItem);
                Properties.Settings.Default.ActiveRequests.Remove(strObj);

                //save properties
                Properties.Settings.Default.Save();

                //refresh previously updated properties
                Properties.Settings.Default.Reload();

                this.ParameterList.Clear();

            }
        }

       
    }
}
