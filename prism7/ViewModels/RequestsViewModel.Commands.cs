using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;
using XModule.Models;
using Autofac;
using System.Windows.Threading;
using System.Windows;

namespace prism7.ViewModels
{
    public partial class RequestsViewModel
    {
       
        /// <summary>
        /// Delegate command that points to the start pipeline method
        /// </summary>
        public DelegateCommand StartPipelineCommand { get; private set; }

        /// <summary>
        /// Delegate commadn that points to the stop pipline method
        /// </summary>
        public DelegateCommand StopPipelineCommand { get; private set; }

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
            this.service = this.container.Resolve<IActiveRequestsService>();

            //Get set difference
            var refreshedRequests = this.service.GetRequests();
            if(refreshedRequests != null)
            {
                var dictRefreshedRequests = refreshedRequests.ToList();//refreshedRequests.ToDictionary(x => x.GetHashCode(), x=>x);
                var currentRequests = this.ActiveRequests.ToList();//ToDictionary(x => x.GetHashCode(), x=>x);

                //compare dictionaries
                var equal = dictRefreshedRequests.Count.Equals(currentRequests.Count);

                //if not true
                if (equal is false)
                {
                    //intersection of sets
                    var intersection = dictRefreshedRequests.Intersect(currentRequests, new RequestObjectEqualityComparer());
                    
                  
                    if(dictRefreshedRequests.Count > currentRequests.Count)
                    {
                        //get the difference of the two lists using equality comparer
                        var diff = dictRefreshedRequests.Except(intersection, new RequestObjectEqualityComparer());

                        //add the difference to the active set
                        for (int x = 0; x < diff.Count(); x++)
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() => { 
                                
                                this.ActiveRequests.Add(diff.ElementAt(x));

                            }));
                        }
                    }
                    if(currentRequests.Count > dictRefreshedRequests.Count)
                    {
                        //get difference
                        var diff = currentRequests.Except(intersection, new RequestObjectEqualityComparer());

                        for (int x=0; x< diff.Count(); x++)
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() => {

                                this.ActiveRequests.Remove(diff.ElementAt(x));

                            }));
                        }

                    }

                    
                }
            }
            
            
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

        /// <summary>
        /// Creates a new Pipeline
        /// </summary>
        private void StartPipeline()
        {
            this.Pipe = new Pipeline.Pipe(this.container, this.loggerFac);
            this.CanStartPipeline = false;
            this.CanStopPipeline = true;
        }

        /// <summary>
        /// Ends the current pipeline
        /// </summary>
        private void StopPipeline()
        {
            this.Pipe.StopPipeline();
            this.CanStopPipeline = false;
            this.CanStartPipeline = true;
        }
    }
}
