﻿using IMDb.Domain.Entities;
using IMDb.Infraestructure.Interfaces.Repositories.Domain.Standard;

namespace IMDb.Infraestructure.Interfaces.Repositories.Domain
{
    public interface ICastRepository : IDomainRepository<Cast> { }
}
