﻿using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using XModule.Models;
using XModule.Services;
using XModule.Tools;
using XModule.Events;

namespace prism7.ViewModels
{
    public partial class MuiViewModel : BindableBase
    {
        private IUnityContainer container;
        private IActiveRequestsService service;
        private IEventAggregator ea;
        private ObservableCollection<RequestObject> requests;
        private ObservableCollection<Pair<string, object>> parameters;
        private RequestObject selectedActiveReqItem;
        public RequestObject SelectedRequestItem { get; set; }

        /// <summary>
        /// The currently selected active request item
        /// </summary>
        public RequestObject SelectedActiveRequestItem
        {
            get { return selectedActiveReqItem;}
            set
            {
                SetProperty(ref selectedActiveReqItem, value);

                //publish event to view details/params
                ea.GetEvent<SelectionChangedEvent>().Publish(selectedActiveReqItem);
            }
        }

        /// <summary>
        /// List of Parameters
        /// </summary>
        public ObservableCollection<Pair<string, object>> ParameterList
        {
            get { return parameters; }
            set { SetProperty(ref parameters, value); }
        }

        /// <summary>
        /// The list of Active Requests
        /// </summary>
        public ObservableCollection<RequestObject> ActiveRequests
        {
            get { return requests; }
            set { SetProperty(ref requests, value); }
        }

        /// <summary>
        /// The main constructor for MuiViewModel that takes an instance of Active Requests Service
        /// </summary>
        /// <param name="service"></param>
        public MuiViewModel(IUnityContainer container, IActiveRequestsService service, IEventAggregator aggregator)
        {
            this.ea = aggregator;
            this.container = container;
            this.service = service;
            this.ActiveRequests = new ObservableCollection<RequestObject>();
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
            this.ActiveRequests = service.GetRequests();
            this.ea.GetEvent<CollectionChangedEvent>().Subscribe((oc) => 
            {
                this.ActiveRequests.Clear();
                this.ActiveRequests = this.service.GetRequests();
            }, ThreadOption.UIThread);
            this.ea.GetEvent<SelectionChangedEvent>().Subscribe((item) => {
                if (item!=null && item.ParameterList != null)
                {
                    this.ParameterList = item.ParameterList;
                }
            });
        }

       
    }
}
