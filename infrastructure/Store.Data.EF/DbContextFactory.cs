using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Store.Data.EF
{
    /// <summary>
    /// BookRepository у нас singleton а dbcontext transient. Если делать DI через
    /// конструктор то dbcontext создасться единственный вместе с синглтоном и будет жить постоянно
    /// а dbcontext создаваыемые далие при запросах не будут иметь отношение к bookrepository
    /// </summary>
    class DbContextFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public StoreDbContext Create(Type repositoryType) //Необходимо, чтобы репозиторий сделать синглтоном, а dbcontext создаются на каждый запрос
        {
            var services = httpContextAccessor.HttpContext.RequestServices;

            var dbContexts = services.GetService<Dictionary<Type, StoreDbContext>>();
            if (!dbContexts.ContainsKey(repositoryType))
                dbContexts[repositoryType] = services.GetService<StoreDbContext>();

            return dbContexts[repositoryType];
        }
    }
}
