using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Defaults;
using Prism.Commands;

namespace NtfsModule.ViewModels
{
    public partial class DataVisualViewModel
    {
        /// <summary>
        /// Delegate command to update charts
        /// </summary>
        public DelegateCommand UpdateChartsCommand { get; private set; }

        /// <summary>
        /// Update charts method associated with the update charts delegate command
        /// </summary>
        public void UpdateCharts()
        {
            var r = new Random();
            foreach (var series in this.PieSeriesCollection)
            {
                foreach (var observable in series.Values.Cast<ObservableValue>())
                {
                    observable.Value = r.Next(0, 10);
                }
            }
        }
    }
}
