using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Model.Api
{
        public class ApiResponse : HttpResponseMessage         
        {
            public HttpStatusCode HttpResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public object Data { get; set; }

            public ApiResponse(HttpStatusCode httpResponseCode)
            {
                HttpResponseCode = httpResponseCode;
            }
        }
    }
