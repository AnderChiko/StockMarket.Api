using StockMarket.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Interfaces
{
    public interface IAlphaVantageAdpter
    {
        Task<MetaData> GetTimeSeriesDaily(string strCompany);
    }
}
