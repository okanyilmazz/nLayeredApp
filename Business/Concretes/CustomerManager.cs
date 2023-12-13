using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        CustomerBusinessRules _businessRules;
        public CustomerManager(ICustomerDal customerDal, IMapper mapper, CustomerBusinessRules businessRules)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedCustomerResponse> AddAsync(CreateCustomerRequest createCustomerRequest)
        {
            await _businessRules.EachCityCanContainMax10Customers(createCustomerRequest.City);
            await _businessRules.IsExistsContactName(createCustomerRequest.ContactName);
            Customer customer = _mapper.Map<Customer>(createCustomerRequest);
            Customer addedCustomer = await _customerDal.AddAsync(customer);
            var mappedCustomer = _mapper.Map<CreatedCustomerResponse>(addedCustomer);
            return mappedCustomer;
        }

        public async Task<GetListCustomerResponse> GetListAsync(PageRequest pageRequest)
        {
            var customerList = await _customerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);
            var mappedCustomer = _mapper.Map<GetListCustomerResponse>(customerList);
            return mappedCustomer;
        }

        public async Task<UpdatedCustomerResponse> UpdateAsync(UpdateCustomerRequest updateCustomerRequest)
        {
            Customer customer = _mapper.Map<Customer>(updateCustomerRequest);
            Customer updatedCustomer = await _customerDal.UpdateAsync(customer);
            var mappedCustomer = _mapper.Map<UpdatedCustomerResponse>(updatedCustomer);
            return mappedCustomer;
        }

        public async Task<DeletedCustomerResponse> DeleteAsync(DeleteCustomerRequest deleteCustomerRequest)
        {
            Customer customer = _mapper.Map<Customer>(deleteCustomerRequest);
            Customer deletedCustomer = await _customerDal.DeleteAsync(customer);
            var mappedCustomer = _mapper.Map<DeletedCustomerResponse>(deletedCustomer);
            return mappedCustomer;
        }
    }
}
