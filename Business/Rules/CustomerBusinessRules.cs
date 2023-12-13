using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CustomerBusinessRules : BaseBusinessRules
    {
        ICustomerDal _customerDal;

        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task EachCityCanContainMax10Customers(string city)
        {
            var result = await _customerDal.GetListAsync(c => c.City == city);
            if (result.Count >= 10)
            {
                throw new BusinessException(BussinessMessages.CityLimit);
            }
        }


        public async Task IsExistsContactName(string name)
        {
            var result = await _customerDal.GetListAsync(c => c.ContactName == name);
            if (result.Count >= 1)
            {
                throw new BusinessException(BussinessMessages.ExistsContactName);
            }
        }
    }
}
