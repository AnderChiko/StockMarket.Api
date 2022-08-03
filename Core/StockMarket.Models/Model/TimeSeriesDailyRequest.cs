using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Model
{
    public class TimeSeriesDaily
    {

        public string function { get; set; } = "TIME_SERIES_DAILY";
        public string symbol { get; set; }
        public string outputsize { get; set; } = "compact";

        public string datatype { get; set; } = "json";

        public TimeSeriesDaily(string _symbol)
        {
            symbol = _symbol;
        }
    }
}
