using Microsoft.Extensions.Options;
using StockMarket.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Core
{
    public abstract class AdpterBase
    {
        protected readonly AlphaVantageOptions _alphaVantageConfig;
        public AdpterBase(IOptions<AlphaVantageOptions> alphaVantageConfig)
        {
            this._alphaVantageConfig = alphaVantageConfig.Value;
        }

        protected virtual HttpClient GetHeader(string baseUrl, string privateKey, string apiHost)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);
            try
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", privateKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }



    }
}
