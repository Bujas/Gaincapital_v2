using Gaincapital_v2.Helper.Exchangeratesapi;
using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace Gaincapital_v2.StepDefinitions
{
    [Binding]
    public class ExchangeratesapiSteps
    {
        private IRestResponse<LastesDto> Response = null;
        private readonly ExchangeratesapiClient ExchangeratesapiClient = new ExchangeratesapiClient();
        private readonly ExchangeratesapiControler ExchangeratesapiControler = new ExchangeratesapiControler();
        [Given(@"I have an endpoint (.*)")]
        public void GivenIHaveAnEndpoint(string restEndpoint)
        {
            ExchangeratesapiClient.SetEndpoint(restEndpoint);
        }

        [When(@"I try get data")]
        public void WhenITryGetData()
        {
            Response = ExchangeratesapiClient.GetLastesExchangeReferenceRates();
        }

        [Then(@"I don't have empty response")]
        public void ThenIDonTHaveEmptyResponse()
        {
            Assert.IsNotNull(ExchangeratesapiControler.GetDataFromResponse(Response));
        }

        [Then(@"I don't have error status code")]
        public void ThenIDonTHaveErrorStatusCode()
        {
            Assert.IsTrue(ExchangeratesapiControler.GetStatusCodeFromResponse(Response) < HttpStatusCode.BadRequest);
        }


        [Then(@"I don't have error status (.*)")]
        public void ThenIDonTHaveErrorStatus(HttpStatusCode code)
        {
            Assert.IsFalse(ExchangeratesapiControler.GetStatusCodeFromResponse(Response).Equals(code));
        }

        [Then(@"I have (.*) status code")]
        public void ThenIHaveStatusCode(int code)
        {
            Assert.IsTrue(ExchangeratesapiControler.GetStatusCodeFromResponse(Response).Equals(HttpStatusCode.OK));
        }

        [Then(@"Value from (.*) is bigger than zero")]
        public void ThenValueFromIsBiggerThanZero(string currency)
        {
            var result = ExchangeratesapiControler.getValueOfCurrency(Response, currency);
            Console.WriteLine(result);
            Assert.IsTrue(result > 0);
        }

        [Then(@"My base currency is an (.*)")]
        public void ThenMyBaseCurrencyIsAn(string currency)
        {
            Assert.IsTrue(ExchangeratesapiControler.getBaseCurrency(Response).Equals(currency));
        }


    }
}
