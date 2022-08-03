using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Model.Responses
{
    public class TimeSeries
    {
        public double Open { get; set; }
        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public double Volume { get; set; }

        public TimeSeries() { }

        public TimeSeries( dynamic _timeSeries) {

            foreach (var item in _timeSeries)
            {
                switch (item.Name)
                {
                    case "1. open":
                        this.Open = item.Value;
                        break;

                    case "2. high":
                        this.High = item.Value;
                        break;

                    case "3. low":
                        this.Low = item.Value;
                        break;

                    case "4. close":
                        this.Close = item.Value;
                        break;

                    case "5. volume":
                        this.Volume = item.Value;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
