
using ETicaretAPI.Application;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {        
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);
            
            services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
            services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();
            services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
            services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
            services.AddScoped<IReadProductRepository, ReadProductRepository>();
            services.AddScoped<IWriteProductRepository, WriteProductRepository>();
        }
    }
}
