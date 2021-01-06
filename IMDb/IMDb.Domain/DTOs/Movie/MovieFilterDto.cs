using IMDb.Domain.Enums;
using System;
using System.Collections.Generic;

namespace IMDb.Domain.DTOs.Movie
{
    public class MovieFilterDto
    {
        public string Name { get; set; }
        public Genre? Genre { get; set; }
        public List<Guid> CastIds { get; set; }
    }
}
