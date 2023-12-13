using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        Task<CreatedCustomerResponse> AddAsync(CreateCustomerRequest createCustomerRequest);
        Task<UpdatedCustomerResponse> UpdateAsync(UpdateCustomerRequest updateCustomerRequest);
        Task<DeletedCustomerResponse> DeleteAsync(DeleteCustomerRequest deleteCustomerRequest);
        Task<GetListCustomerResponse> GetListAsync(PageRequest pageRequest);
    }
}
