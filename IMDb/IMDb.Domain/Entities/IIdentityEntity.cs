using System;

namespace IMDb.Domain.Entities
{
    public interface IIdentityEntity
    {
        Guid Id { get; set; }
    }
}
