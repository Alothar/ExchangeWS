using ExchangeWS.SerializableClasses;
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

        public ExchangeRatesSeries GetExchangeRate(String currencyCode)
        {
            ExchangeRatesSeries e = new ExchangeRatesSeries();
            System.Threading.Tasks.Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "exchangerates/rates/a/" + currencyCode);
            if (t.Result.IsSuccessStatusCode)
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(ExchangeRatesSeries));
                System.IO.StreamReader sr = new System.IO.StreamReader(t.Result.Content.ReadAsStringAsync().Result);
                e = (ExchangeRatesSeries)ser.Deserialize(sr);
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