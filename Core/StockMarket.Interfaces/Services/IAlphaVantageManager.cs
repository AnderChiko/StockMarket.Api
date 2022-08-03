using StockMarket.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Interfaces.Services
{
    public interface IAlphaVantageManager
    {
        Task<List<MetaData>> GetTimeSeriesDaily(string strCompanyArray);
    }
}
