using IMDb.Domain.Enums;
using System;

namespace IMDb.Domain.DTOs.Movie
{
    public class CastDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CastType CastType { get; set; }

        public CastDto(Entities.Cast cast)
        {
            Id = cast.Id;
            Name = cast.Name;
            CastType = (CastType)cast.CastTypeId;
        }
    }
}
