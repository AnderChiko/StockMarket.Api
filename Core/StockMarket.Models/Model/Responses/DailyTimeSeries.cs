using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Model.Responses
{
    public class DailyTimeSeries
    {
        public string Date { get; set; }
       
        public TimeSeries TimeSeries { get; set; }

        public DailyTimeSeries() { }

        public DailyTimeSeries(dynamic _date ,dynamic _timeSeries)
        {
            this.Date = _date;
            this.TimeSeries = new TimeSeries(_timeSeries);
        }
    }
}
