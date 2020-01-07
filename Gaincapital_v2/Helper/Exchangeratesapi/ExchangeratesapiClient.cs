using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
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

        public LastesDto GetLastesExchangeReferenceRates()
        {
            var request = new RestRequest(LastesExchangeReferenceRatesUrl, Method.GET);
            IRestResponse<LastesDto> response = endpoint.Execute<LastesDto>(request);
            return response.Data;
        }
    }
}
