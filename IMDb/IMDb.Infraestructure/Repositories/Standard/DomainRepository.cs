﻿using IMDb.Domain.Entities;
using IMDb.Infraestructure.Interfaces.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Infraestructure.Repositories.Standard
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                             IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
