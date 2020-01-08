using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using RestSharp;

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
    }
}
