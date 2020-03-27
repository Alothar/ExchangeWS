using ExchangeWS.SerializableClasses;
using System;
using System.Linq;

namespace ExchangeWS
{
    public class ExchangeService : IExchangeService
    {
        public ExchangeRateType GetExchangeRateForCurrency(string currencyCode)
        {
            if (currencyCode == null)
            {
                throw new ArgumentNullException("currencyCode");
            }

            
            RestNBPService.RestNBPService r = RestNBPService.RestNBPService.Instance;
            ExchangeRates ers = r.GetExchangeRate(currencyCode);
            if (ers.code == null)
            {
                throw new Exception("There is no exchange rate for such currency code");
            }
            return convertRestNBPResponse(ers);
        }

        public ExchangeRateType convertRestNBPResponse(ExchangeRates ers)
        {
            ExchangeRateType e = new ExchangeRateType();
            e.Currency = ers.currency;
            e.Code = ers.code;
            e.Date = ers.rates.FirstOrDefault<Rate>().effectiveDate;
            e.Rate = ers.rates.FirstOrDefault<Rate>().mid;

            return e;
        }
    }
}
