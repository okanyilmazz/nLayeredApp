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

namespace Business.AutoMapper.Profiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetListProductResponse>().ReverseMap();
            CreateMap<Product, CreatedProductResponse>().ReverseMap();
            CreateMap<Product,UpdatedProductResponse>().ReverseMap();
            CreateMap<Product, DeletedProductResponse>().ReverseMap();

            CreateMap<Paginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();


            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Product, DeleteProductRequest>().ReverseMap();

        }
    }
}
