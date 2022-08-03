using StockMarket.Interfaces;
using StockMarket.Interfaces.Services;
using StockMarket.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Core.Services
{
    public class AlphaVantageManager : IAlphaVantageManager
    {

        private readonly IAlphaVantageAdpter _alphaVantageAdpter;
        public AlphaVantageManager(IAlphaVantageAdpter alphaVantageAdpter)          
        {
            this._alphaVantageAdpter = alphaVantageAdpter;
        }

        public async Task<List<MetaData>> GetTimeSeriesDaily(string strCompanyArray)
        {
            //to do : to apply  the rules
            // 5 calls per minute 
            // 500 calls per day
        
             var resultList = new List<MetaData>();
             string[] companyList = strCompanyArray.Split(',');

            foreach (string company in companyList)
            {
                try
                {
                    var cc = await _alphaVantageAdpter.GetTimeSeriesDaily(company);
                    resultList.Add(cc);
                }
                catch(Exception ex)
                {
                    // exclude with errors
                    resultList.Add(new MetaData(company,ex.Message));
                }                 
            }

            //to do : only successful ones returned
            return resultList.Where(x=> x.ErrorMessage == null).ToList();
        }
    }
}
