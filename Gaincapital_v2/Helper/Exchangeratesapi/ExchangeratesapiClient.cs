using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Gaincapital_v2.Helper.Exchangeratesapi
{
    class ExchangeratesapiClient
    {
        public RestClient endpoint = null;
        private string LastesExchangeReferenceRatesUrl = "/latest";


        public RestClient SetEndpoint(string restEndpoint)
        {
            endpoint = new RestClient(restEndpoint);
            return endpoint;
        }

        public IRestResponse<LastesDto> GetLastesExchangeReferenceRates()
        {
            var request = new RestRequest(LastesExchangeReferenceRatesUrl, Method.GET);
            IRestResponse<LastesDto> response = endpoint.Execute<LastesDto>(request);
            return response;
        }

        public int GetStatusCodeFromResponse(IRestResponse<LastesDto> response)
        {
            return (int)response.StatusCode;
        }   
        public LastesDto GetDataFromResponse(IRestResponse<LastesDto> response)
        {
            return response.Data;
        }

        public double getValueOfCurrency(IRestResponse<LastesDto> response , string currency)
        {
            var json = new JavaScriptSerializer().Serialize(response.Data.Rates);
            var jsonWithUpperKeys = JObject.Parse(json.ToUpper());
            return Convert.ToDouble(jsonWithUpperKeys[currency].ToString());

        }
    }
}
