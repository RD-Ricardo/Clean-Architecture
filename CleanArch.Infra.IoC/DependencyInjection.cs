using System;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Mapping;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectioMysql = configuration.GetConnectionString("DefaultConnection");

            //Dbcontext
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseMySql(connectioMysql, ServerVersion.AutoDetect(connectioMysql), 
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Repositoty
            services.AddScoped<ICategoryRepository, CategoryRepository>();    
            services.AddScoped<IProductRepository, ProductRepository>(); 

            //Service 
            services.AddScoped<ICategoryService, CategoryService>();    
            services.AddScoped<IProductService, ProductService>();

            //AutoMapper  
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Mediator
            var myHandles = AppDomain.CurrentDomain.Load("CleanArch.Application");
            services.AddMediatR(myHandles);
            return services;
        }
    }
}
