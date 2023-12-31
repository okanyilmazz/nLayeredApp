﻿using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IProductService
{
    Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);

    // Example 1
    // Task<CreatedProductResponse> Update(Product product);

    // Example 2
    Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest);

    //Example 1
    //Task<CreatedProductResponse> Delete(Product product);

    //Example 2
    Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest);

}

//response request pattern
//GetListProductRepsonse
//Automapper entegrasyonu getiriniz.