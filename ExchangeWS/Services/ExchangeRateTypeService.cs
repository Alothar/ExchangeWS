using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeWS.Services
{
    public class ExchangeRateTypeService :IExchangeRateTypeService
    {
        private readonly IExchangeRateTypeRepository _repository;

        public ExchangeRateTypeService(IExchangeRateTypeRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public bool DoesItemExist(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(code);
            }

            return _repository.DoesItemExist(code);
        }

        public ExchangeRateType Find(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("code");
            }

            return _repository.Find(code);
        }

        public IEnumerable<ExchangeRateType> GetData()
        {
            return _repository.All;
        }

        public void InsertData(ExchangeRateType item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _repository.Insert(item);
        }

        public void UpdateData(ExchangeRateType item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _repository.Update(item);
        }

        public void DeleteData(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("code");
            }

            _repository.Delete(code);
        }
    }
}