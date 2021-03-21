using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Data.EF
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Transient// один экземпляр на каждый запрос
                );

            services.AddScoped<Dictionary<Type, StoreDbContext>>();// один экземпляр на каждый веб запрос(некий контейнер который хранит http context запроса) 
            services.AddSingleton<DbContextFactory>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
