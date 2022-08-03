using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Interfaces;
using StockMarket.Interfaces.Logging;
using StockMarket.Interfaces.Services;
using StockMarket.Models.Model.Api;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StockMarket.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AlphaVantageIntergrationController : ControllerBase
    {

        private readonly IAlphaVantageManager _alphaVantageManager;
        private readonly ILoggingManager<AlphaVantageIntergrationController> _logger;

        public AlphaVantageIntergrationController(IAlphaVantageManager alphaVantageManager, ILoggingManager<AlphaVantageIntergrationController> logger)
        {
            this._alphaVantageManager = alphaVantageManager;
            this._logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> TimeSeriesDaily(string company)
        {
            try
            {
                ApiResponse apiResponse = new ApiResponse(HttpStatusCode.OK);
                apiResponse.Data = await _alphaVantageManager.GetTimeSeriesDaily(company);
                return apiResponse;
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.InternalServerError)
                {
                    ResponseMessage = ex.Message
                };
            }
        }
    }
}
