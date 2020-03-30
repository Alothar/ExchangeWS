using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeWS.Services
{
    public interface IExchangeRateTypeService
    {
        bool DoesItemExist(string code);
        ExchangeRateType Find(string code);
        IEnumerable<ExchangeRateType> GetData();
        void InsertData(ExchangeRateType item);
        void UpdateData(ExchangeRateType item);
        void DeleteData(string id);
    }
}