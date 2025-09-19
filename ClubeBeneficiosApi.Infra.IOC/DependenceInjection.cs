using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosApi.Application.Services;
using ClubeBeneficiosAPi.Domain.Authentication;
using ClubeBeneficiosAPi.Domain.Repositories;
using ClubeBeneficiosApi.Infra.Data.Authentication;
using ClubeBeneficiosApi.Infra.Data.Context;
using ClubeBeneficiosApi.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClubeBeneficiosApi.Infra.IOC
{
    public static class DependencyInjection
    {
        /// <summary> Injetando Banco </summary>
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConnectionDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProducttRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            

            return services;
        }

        /// <summary> Injetando AutoMapper e serviços </summary>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
        
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();
    
            return services;
        }
    }
}
