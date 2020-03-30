using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ExchangeWS
{
    [ServiceContract]
    public interface IExchangeService
    {
        [OperationContract]
        ExchangeRateType GetExchangeRateForCurrency(string currencyCode);

        [OperationContract]
        List<ExchangeRateType> GetExchangeRateTypes();
    }

    [DataContract]
    public class ExchangeRateType
    {
        string currency;
        string code;
        string date;
        double rate;

        [DataMember]
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        [DataMember]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
    }
}
