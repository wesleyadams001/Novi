using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;
using XModule.Models;

namespace prism7.ViewModels
{
    public partial class MuiViewModel
    {
       
        /// <summary>
        /// Delegate command that points to the viewing parameters function
        /// </summary>
        public DelegateCommand ViewParametersCommand { get; private set; }

        /// <summary>
        /// Method that allows for the viewing of parameters
        /// </summary>
        private void ViewParameters()
        {
            this.ParameterList.Clear();

            for (int x = 0; x < this.SelectedRequestItem.ParameterList.Count; x++)
            {
                this.ParameterList.Add(this.SelectedRequestItem.ParameterList.ElementAt(x));
            }
        }

        /// <summary>
        /// Updates the services
        /// </summary>
        private void UpdateServices()
        {
            //resolve the interface
            this.service = container.Resolve<IActiveRequestsService>();

            var services = this.service.GetRequests();

            //get requests
            this.ActiveRequests.Add()
        }
    }
}
