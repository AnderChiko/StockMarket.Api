using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Model.Responses
{

    public class MetaData
    {
        public string Information { get; set; }
        public string Company { get; set; }
        public string LastRefreshed { get; set; }
        public string OutputSize { get; set; }
        public string TimeZone { get; set; }
        public DailyTimeSeries[] DailyTimeSeries  { get; set; }
           
        //graphs information volume/day 
        public string[] DatesArray { get; set; }
        public double[] DailyVolumeArray { get; set; }

        //error
        public string ErrorMessage { get; set; }
        public MetaData() { }

        public MetaData(string _company,string _errorMessage)
        {
            this.Company = _company;
            this.ErrorMessage = _errorMessage;  
        }

        public MetaData(string _company) {
               this.Company = _company;
        }

        // to do : remove to extension class
        public MetaData(dynamic dynamicObject) {

            //check response have error message
            var ErrorData = dynamicObject["Error Message"];

            if (ErrorData != null)
            {                               
                  this.ErrorMessage = ErrorData.Value; 
            }
            else
            {
                // no error continue
                var metaData = dynamicObject["Meta Data"];
                foreach (var item in metaData)
                {
                    switch (item.Name)
                    {
                        case "1. Information":
                            this.Information = item.Value;
                            break;

                        case "2. Symbol":
                            this.Company = item.Value;
                            break;

                        case "3. Last Refreshed":
                            this.LastRefreshed = item.Value;
                            break;

                        case "4. Output Size":
                            this.OutputSize = item.Value;
                            break;

                        case "5. Time Zone":
                            this.TimeZone = item.Value;
                            break;

                        default:
                            break;
                    }
                }

                // get time series
                var timeSeries = dynamicObject["Time Series (Daily)"];

                List<string> list = new List<string>();
                List<DailyTimeSeries> timesList = new List<DailyTimeSeries>();
                // populate time series
                foreach (var item in timeSeries)
                {
                    list.Add(item.Name);
                    timesList.Add(new DailyTimeSeries(item.Name, item.Value));
                }

                //populate daily volumes is array for line graph
                List<double> dailyVolume = new List<double>();
                foreach (var item in timesList)
                    dailyVolume.Add(item.TimeSeries.Volume);

                // asign values to object properties
                this.DailyTimeSeries = timesList.ToArray();
                this.DatesArray = list.ToArray();
                this.DailyVolumeArray = dailyVolume.ToArray();
            }
        }
    }
}
