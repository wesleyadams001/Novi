using Autofac;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using XModule.Services;

namespace NtfsModule.ViewModels
{
    public partial class DataVisualViewModel : BindableBase
    {
        private SeriesCollection _seriesCollection;
        public SeriesCollection PieSeriesCollection
        {
            get { return _seriesCollection; }
            set { SetProperty(ref _seriesCollection, value); OnPropertyChanged("seriesCollection"); }
        }

        /// <summary>
        /// Default constructor for the data visual
        /// </summary>
        public DataVisualViewModel(IComponentContext container, IKeyService service, IEventAggregator eventAggregator, ILoggerFactory loggerfac)
        {
            this.PieSeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(8) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Mozilla",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(6) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Opera",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Explorer",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true
                }
            };

            var r = new Random();

            Values = new ChartValues<HeatPoint>
            {
                //X means sales man
                //Y is the day
 
                //"Jeremy Swanson"
                new HeatPoint(0, 0, r.Next(0, 10)),
                new HeatPoint(0, 1, r.Next(0, 10)),
                new HeatPoint(0, 2, r.Next(0, 10)),
                new HeatPoint(0, 3, r.Next(0, 10)),
                new HeatPoint(0, 4, r.Next(0, 10)),
                new HeatPoint(0, 5, r.Next(0, 10)),
                new HeatPoint(0, 6, r.Next(0, 10)),
 
                //"Lorena Hoffman"
                new HeatPoint(1, 0, r.Next(0, 10)),
                new HeatPoint(1, 1, r.Next(0, 10)),
                new HeatPoint(1, 2, r.Next(0, 10)),
                new HeatPoint(1, 3, r.Next(0, 10)),
                new HeatPoint(1, 4, r.Next(0, 10)),
                new HeatPoint(1, 5, r.Next(0, 10)),
                new HeatPoint(1, 6, r.Next(0, 10)),
 
                //"Robyn Williamson"
                new HeatPoint(2, 0, r.Next(0, 10)),
                new HeatPoint(2, 1, r.Next(0, 10)),
                new HeatPoint(2, 2, r.Next(0, 10)),
                new HeatPoint(2, 3, r.Next(0, 10)),
                new HeatPoint(2, 4, r.Next(0, 10)),
                new HeatPoint(2, 5, r.Next(0, 10)),
                new HeatPoint(2, 6, r.Next(0, 10)),
 
                //"Carole Haynes"
                new HeatPoint(3, 0, r.Next(0, 10)),
                new HeatPoint(3, 1, r.Next(0, 10)),
                new HeatPoint(3, 2, r.Next(0, 10)),
                new HeatPoint(3, 3, r.Next(0, 10)),
                new HeatPoint(3, 4, r.Next(0, 10)),
                new HeatPoint(3, 5, r.Next(0, 10)),
                new HeatPoint(3, 6, r.Next(0, 10)),
 
                //"Essie Nelson"
                new HeatPoint(4, 0, r.Next(0, 10)),
                new HeatPoint(4, 1, r.Next(0, 10)),
                new HeatPoint(4, 2, r.Next(0, 10)),
                new HeatPoint(4, 3, r.Next(0, 10)),
                new HeatPoint(4, 4, r.Next(0, 10)),
                new HeatPoint(4, 5, r.Next(0, 10)),
                new HeatPoint(4, 6, r.Next(0, 10))
            };

            Days = new[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            SalesMan = new[]
            {
                "Jeremy Swanson",
                "Lorena Hoffman",
                "Robyn Williamson",
                "Carole Haynes",
                "Essie Nelson"
            };

            this.UpdateChartsCommand = new DelegateCommand(UpdateCharts);
        }

        public ChartValues<HeatPoint> Values { get; set; }
        public string[] Days { get; set; }
        public string[] SalesMan { get; set; }
    }
}
