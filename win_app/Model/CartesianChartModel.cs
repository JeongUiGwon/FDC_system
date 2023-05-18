using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class CartesianChartModel
    {
        public string title { get; set; }
        public SeriesCollection ChartSeries { get; set; }
        public List<string> ChartLabels { get; set; }
        public CartesianChartModel(string title, SeriesCollection ChartSeries, List<string> ChartLabels) 
        {
            this.title = title;
            this.ChartSeries = ChartSeries;
            this.ChartLabels = ChartLabels;
        }
    }
}
