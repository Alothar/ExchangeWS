using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeWS.Services
{
    public interface IExchangeRateTypeRepository
    {
        bool DoesItemExist(string code);
        IEnumerable<ExchangeRateType> All { get; }
        ExchangeRateType Find(string code);
        void Insert(ExchangeRateType item);
        void Update(ExchangeRateType item);
        void Delete(string id);
    }
}