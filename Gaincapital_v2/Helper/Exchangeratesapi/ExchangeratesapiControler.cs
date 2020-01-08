using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;

namespace Gaincapital_v2.Helper.Exchangeratesapi
{
    class ExchangeratesapiControler
    {
        public HttpStatusCode GetStatusCodeFromResponse(IRestResponse<LastesDto> response)
        {
            return response.StatusCode;
        }
        public LastesDto GetDataFromResponse(IRestResponse<LastesDto> response)
        {
            return response.Data;
        }

        public double getValueOfCurrency(IRestResponse<LastesDto> response, string currency)
        {
            var json = new JavaScriptSerializer().Serialize(response.Data.Rates);
            var jsonWithUpperKeys = JObject.Parse(json.ToUpper());
            return Convert.ToDouble(jsonWithUpperKeys[currency].ToString());
        }

        public string getBaseCurrency(IRestResponse<LastesDto> response)
        {
            return response.Data.Base;
        }

    }
}
