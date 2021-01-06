using IMDb.Domain.Entities;
using System;

namespace IMDb.Domain.DTOs.Movie
{
    public class CastOfMovieDto
    {
        public Guid Id { get; set; }
        public CastDto Cast { get; set; }

        public CastOfMovieDto(CastOfMovie castOfMovie)
        {
            Id = castOfMovie.Id;
            Cast = new CastDto(castOfMovie.Cast);
        }
    }
}
