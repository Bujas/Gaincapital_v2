using Gaincapital_v2.Helper.Exchangeratesapi;
using Gaincapital_v2.Helper.Exchangeratesapi.Dto;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;

namespace Gaincapital_v2.StepDefinitions
{
    [Binding]
    public class ExchangeratesapiSteps
    {
        private LastesDto lastes = null;
        private readonly ExchangeratesapiClient Rest = new ExchangeratesapiClient();
        [Given(@"I have an example endpoint (.*)")]
        public void GivenIHaveAnExampleEndpoint(string restEndpoint)
        {
            Rest.SetEndpoint(restEndpoint);
        }

        [When(@"I search for all customers")]
        public void WhenISearchForAllCustomers()
        {
            Console.WriteLine("Hi Hi World");
            lastes = Rest.GetLastesExchangeReferenceRates();
            string output1 = JsonConvert.SerializeObject(lastes);
            string output2 = JsonConvert.SerializeObject(lastes.Base);
            string output3 = JsonConvert.SerializeObject(lastes.Date);
            string output4 = JsonConvert.SerializeObject(lastes.Rates.CAD);
            Console.WriteLine(output1);
            Console.WriteLine("");
            Console.WriteLine(output2);
            Console.WriteLine("");
            Console.WriteLine(output3);
            Console.WriteLine("");     
            Console.WriteLine(output4);
            Console.WriteLine("");

        }

        [Then(@"the result contains customer Laura")]
        public void ThenTheResultContainsCustomerLaura()
        {
            string output = JsonConvert.SerializeObject(lastes);
            //Console.WriteLine(output);
    
        }
    }
}
