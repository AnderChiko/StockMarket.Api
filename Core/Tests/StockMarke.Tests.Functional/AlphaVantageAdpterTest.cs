using Microsoft.Extensions.DependencyInjection;
using StockMarket.Core;
using StockMarket.Interfaces;
using StockMarket.Models.Model.Responses;
using StockMarket.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockMarke.Tests.Functional
{
    public class AlphaVantageAdpterTest : TestHarnessBase
    {

        public AlphaVantageAdpterTest()
        {
            _services.AddCore();
           
            ReBuildServices();
        }
       
        [Theory]
        [InlineData("MSFT", 1)]
        [InlineData("AAPL", 1)]
        [InlineData("NFLX", 1)]
        [InlineData("FB", 1)]
        [InlineData("AMZN", 1)]
        public void GetTimeSeriesDailys(string company,int count)
        {

            var result = RunInScope<IAlphaVantageAdpter, MetaData>(
                 (IAlphaVantageAdpter instance, IServiceScope scope) =>
                 {
                     var results = instance.GetTimeSeriesDaily(company).Result;

                     return results;
                 });

            Assert.NotNull(result);
            Assert.Null(result.ErrorMessage);
        }

    }
}
