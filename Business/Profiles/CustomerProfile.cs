using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
            CreateMap<Customer, CreatedCustomerResponse>().ReverseMap();

            CreateMap<Customer, UpdateCustomerRequest>().ReverseMap();
            CreateMap<Customer, UpdatedCustomerResponse>().ReverseMap();

            CreateMap<Customer, DeleteCustomerRequest>().ReverseMap();
            CreateMap<Customer, DeletedCustomerResponse>().ReverseMap();

            CreateMap<Customer, GetListCustomerResponse>().ReverseMap();
            CreateMap<IPaginate<Customer>, Paginate<DeletedCustomerResponse>>().ReverseMap();
        }
    }
}
