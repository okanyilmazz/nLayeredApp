using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<CategoryBusinessRules>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
