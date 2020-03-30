using ExchangeWS.SerializableClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeWS.Services
{
    public class ExchangeRateTypeRepository : IExchangeRateTypeRepository
    {
        private List<ExchangeRateType> _todoList;

        public ExchangeRateTypeRepository()
        {
            InitializeData();
        }

        public IEnumerable<ExchangeRateType> All
        {
            get { return _todoList; }
        }

        public bool DoesItemExist(string code)
        {
            return _todoList.Any(item => item.Code == code);
        }

        public ExchangeRateType Find(string code)
        {
            return _todoList.Where(item => item.Code == code).FirstOrDefault();
        }

        public void Insert(ExchangeRateType item)
        {
            _todoList.Add(item);
        }

        public void Update(ExchangeRateType item)
        {
            var todoItem = Find(item.Code);
            var index = _todoList.IndexOf(todoItem);
            _todoList.RemoveAt(index);
            _todoList.Insert(index, item);
        }

        public void Delete(string id)
        {
            _todoList.Remove(Find(id));
        }

        #region Helpers

        private void InitializeData()
        {
            _todoList = new List<ExchangeRateType>();

            ExchangeService exchangeService = new ExchangeService();

            var USD = exchangeService.GetExchangeRateForCurrency("USD");

            var EUR = exchangeService.GetExchangeRateForCurrency("EUR");

            var PLN = exchangeService.GetExchangeRateForCurrency("PLN");

            _todoList.Add(USD);
            _todoList.Add(EUR);
            _todoList.Add(PLN);
        }

        #endregion
    }
}