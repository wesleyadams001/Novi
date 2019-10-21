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
        /// Delegate command that points to the request method
        /// </summary>
        public DelegateCommand MakeRequestCommand { get; private set; }

        /// <summary>
        /// Delegate command that points to the viewing parameters function
        /// </summary>
        public DelegateCommand ViewParametersCommand { get; private set; }

        /// <summary>
        /// Method that allows for the viewing of parameters
        /// </summary>
        private void ViewParameters()
        {
            //clear the list 
            this.ParameterList.Clear();

            for (int x = 0; x < this.SelectedRequestItem.ParameterList.Count; x++)
            {
                //Add item to parameter list
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

            //get requests
            this.ActiveRequests = this.service.GetRequests();
        }

        /// <summary>
        /// Method that drops a request on the request pipeline
        /// </summary>
        /// <param name="ro"></param>
        private void MakeRequest()
        {
            for(int x = 0; x< this.requests.Count; x++)
            {
                //Post to the pipeline
                this.Pipe.Post(this.requests.ElementAt(x));
            }
            

        }
    }
}
