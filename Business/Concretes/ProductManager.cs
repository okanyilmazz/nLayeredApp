using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
    {
        Product product = new Product();
        product.Id = Guid.NewGuid();
        product.ProductName = createProductRequest.ProductName;
        product.QuantityPerUnit = createProductRequest.QuantityPerUnit;
        product.UnitsInStock = createProductRequest.UnitsInStock;
        product.UnitPrice = createProductRequest.UnitPrice;

        Product createdProduct = await _productDal.AddAsync(product);

        CreatedProductResponse createdProductResponse = new CreatedProductResponse();

        createdProductResponse.Id = createdProduct.Id;
        createdProductResponse.ProductName = createdProduct.ProductName;
        createdProductResponse.UnitPrice = createdProduct.UnitPrice;
        createdProductResponse.QuantityPerUnit = createdProduct.QuantityPerUnit;
        createdProductResponse.UnitsInStock = createdProduct.UnitsInStock;

        return createdProductResponse;
    }

    public async Task<IPaginate<GetListProductResponse>> GetListAsync()
    {

        var productList = await _productDal.GetListAsync();

        List<GetListProductResponse> listResponseItems = new List<GetListProductResponse>();

        foreach (var product in productList.Items)
        {
            listResponseItems.Add(new GetListProductResponse
            {
                Id = product.Id,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            });
        }

        Paginate<GetListProductResponse> listResponse = new Paginate<GetListProductResponse>();
        listResponse.Items = listResponseItems;
        listResponse.Count = productList.Count;
        listResponse.Index = productList.Index;
        listResponse.Size = productList.Size;
        listResponse.From = productList.From;
        listResponse.Pages = productList.Pages;

        return listResponse;
    }
}
