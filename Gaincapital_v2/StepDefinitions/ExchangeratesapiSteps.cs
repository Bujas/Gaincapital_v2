using Gaincapital_v2.Helper.Exchangeratesapi;
using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace Gaincapital_v2.StepDefinitions
{
    [Binding]
    public class ExchangeratesapiSteps
    {
        private IRestResponse<LastesDto>  Response = null;
        private readonly ExchangeratesapiClient Rest = new ExchangeratesapiClient();
        [Given(@"I have an endpoint (.*)")]
        public void GivenIHaveAnEndpoint(string restEndpoint)
        {
            Rest.SetEndpoint(restEndpoint);
        }

        [When(@"I try get all data")]
        public void WhenITryGetAllData()
        {
            Response = Rest.GetLastesExchangeReferenceRates();
        }

        [Then(@"I don't have null object")]
        public void ThenIDonTHaveNullObject()
        {
            Assert.IsNotNull(Rest.GetDataFromResponse(Response));
        }

        [Then(@"I don't have error status code")]
        public void ThenIDonTHaveErrorStatusCode()
        {
            Assert.IsTrue(Rest.GetStatusCodeFromResponse(Response)<400);
        }


        [Then(@"I don't have error status (.*)")]
        public void ThenIDonTHaveErrorStatus(string code)
        {
            Assert.IsFalse(Rest.GetStatusCodeFromResponse(Response).Equals(Convert.ToInt32(code)));
        }

        [Then(@"I have (.*) status code")]
        public void ThenIHaveStatusCode(int code)
        {
            Assert.IsTrue(Rest.GetStatusCodeFromResponse(Response).Equals(code));
        }

        [Then(@"Value from (.*) is bigger than zero")]
        public void ThenValueFromIsBiggerThanZero(string currency)
        {
          var result =  Rest.getValueOfCurrency(Response, currency);
            Console.WriteLine(result);
            Assert.IsTrue(result > 0);
        }


    }
}
