using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Models.Options
{
    public class AlphaVantageOptions
    {
        public string BaseUrl { get; set; }

        public string XRapidAPIKey { get; set; }

        public string XRapidAPIHost { get; set; }

        public string Companies { get; set; }
    }
}
