using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using XModule.Models;
using XModule.Services;
using XModule.Tools;
using XModule.Events;
using XModule.Interfaces;
using Autofac;
using System.Timers;

namespace AclProcessor.ViewModels
{
    public partial class RequestsViewModel : BindableBase
    {
        private IComponentContext container;
        private IActiveRequestsService service;
        private IEventAggregator ea;
        private ILoggerFactory loggerFac;
        private ILogger logger;
        private ObservableCollection<RequestObject> requests;
        private ObservableCollection<Pair<string, object>> parameters;
        private RequestObject selectedActiveReqItem;
        private Pipeline.Pipe Pipe;
        private System.Timers.Timer Timer;
        private bool _canStartPipeline;
        private bool _canStopPipeline;
        public RequestObject SelectedRequestItem { get; set; }

        /// <summary>
        /// Indicates whether the pipeline is currently inactive and can be started
        /// </summary>
        public bool CanStartPipeline 
        {
            get { return _canStartPipeline; }
            set
            {
                SetProperty(ref _canStartPipeline, value);
            } 
        }

        /// <summary>
        /// Indicates whether the pipeline is currently active can be stopped
        /// </summary>
        public bool CanStopPipeline 
        {
            get { return _canStopPipeline; }
            set
            {
                SetProperty(ref _canStopPipeline, value);
            } 
        }

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
        public RequestsViewModel(IComponentContext container, IActiveRequestsService service, IEventAggregator aggregator, ILoggerFactory loggerFactory)
        {
            this.ea = aggregator;
            this.loggerFac = loggerFactory;
            this.logger = loggerFactory.Create<RequestsViewModel>();
            this.container = container;
            this.service = service;
            this.ActiveRequests = new ObservableCollection<RequestObject>();
            this.ParameterList = new ObservableCollection<Pair<string, object>>();
            this.ActiveRequests = service.GetRequests();
            this.Pipe = null;
            this.MakeRequestCommand = new DelegateCommand(MakeRequest);
            this.Timer = new Timer();
            Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            Timer.Interval = 500;
            Timer.Enabled = true;
            this.CanStartPipeline = true;
            this.CanStopPipeline = false;
            this.StartPipelineCommand = new DelegateCommand(StartPipeline);
            this.StopPipelineCommand = new DelegateCommand(StopPipeline);

            this.ea.GetEvent<SelectionChangedEvent>().Subscribe((item) => {
                if (item!=null && item.ParameterList != null)
                {
                    this.ParameterList = item.ParameterList;
                }
            });
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            UpdateServices();
        }


    }
}
