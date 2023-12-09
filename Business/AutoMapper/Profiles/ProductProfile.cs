using AutoMapper;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Profiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetListProductResponse>().ReverseMap();
            CreateMap<Paginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();
        }
    }
}
