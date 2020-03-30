using ExchangeWS.SerializableClasses;
using ExchangeWS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace ExchangeWS
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ExchangeService : IExchangeService
    {
        static readonly IExchangeRateTypeService exchangeRateService = new ExchangeRateTypeService(new ExchangeRateTypeRepository());
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

        public List<ExchangeRateType> GetExchangeRateTypes()
        {
            return exchangeRateService.GetData().ToList();
        }
    }
}
