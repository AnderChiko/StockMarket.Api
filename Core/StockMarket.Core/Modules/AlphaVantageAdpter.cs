
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using StockMarket.Interfaces;
using StockMarket.Models.Model.Responses;
using StockMarket.Models.Options;

namespace StockMarket.Core.Modules
{
    public class AlphaVantageAdpter : AdpterBase, IAlphaVantageAdpter
    {
        public AlphaVantageAdpter(IOptions<AlphaVantageOptions> alphaVantageConfig)
            : base(alphaVantageConfig)
        {

        }

        public async Task<MetaData> GetTimeSeriesDaily(string strCompany)
        {

            string url = string.Format("https://alphavantage.p.rapidapi.com/query?function=TIME_SERIES_DAILY&symbol={0}&outputsize=compact&datatype=json", strCompany);

            //to do : cretae header funtion in the base class for re use
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _alphaVantageConfig.XRapidAPIKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _alphaVantageConfig.XRapidAPIHost);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                                
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(jsonString)!;
                return new MetaData(dynamicObject);
            }
            else
                return new MetaData(strCompany, response.ReasonPhrase);
        }
    }    
}
