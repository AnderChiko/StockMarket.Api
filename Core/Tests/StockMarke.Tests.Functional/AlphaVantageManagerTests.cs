using Microsoft.Extensions.DependencyInjection;
using StockMarket.Core;
using StockMarket.Interfaces.Services;
using StockMarket.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockMarket.Tests.Functional
{
    public class AlphaVantageManagerTests : TestHarnessBase
    {

        public AlphaVantageManagerTests()
        {
            _services.AddCore();

            ReBuildServices();
        }

        [Theory]
        [InlineData("MSFT,AAPL,NFLX,FB,AMZN", 5)]
        
        public void GetTimeSeriesDailys(string companyArray, int count)
        {

            var result = RunInScope<IAlphaVantageManager, List<MetaData>>(
                 (IAlphaVantageManager instance, IServiceScope scope) =>
                 {
                     var results = instance.GetTimeSeriesDaily(companyArray).Result;

                     return results;
                 });

            Assert.NotNull(result);
            Assert.Equal(result.Count(), count);

            var errorsCount = result.Count(x=> x.ErrorMessage != null);

            Assert.Equal(1, errorsCount);

        }

    }
}
