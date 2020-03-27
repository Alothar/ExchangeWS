using ExchangeWS.SerializableClasses;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ExchangeWS.RestNBPService
{
    public class RestNBPService
    {
        public HttpClient _client;

        private RestNBPService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://api.nbp.pl/api/")
            };
        }

        public ExchangeRates GetExchangeRate(String currencyCode)
        {
            ExchangeRates e = new ExchangeRates();
            System.Threading.Tasks.Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "exchangerates/rates/a/" + currencyCode);
            if (t.Result.IsSuccessStatusCode)
            {
                string result = t.Result.Content.ReadAsStringAsync().Result;
                e = JsonConvert.DeserializeObject<ExchangeRates>(result);
            }
            return e;
        }

        public static RestNBPService Instance { get { return NestedNBPRestService.instance; } }
        private class NestedNBPRestService
        {
            static NestedNBPRestService()
            {
            }

            internal static readonly RestNBPService instance = new RestNBPService();
        }
    }
}