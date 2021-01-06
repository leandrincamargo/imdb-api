using IMDb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDb.Domain.DTOs.Movie
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public decimal? Average { get; set; }
        public int? NumberOfVotes { get; set; }
        public ICollection<CastOfMovieDto> CastOfMovie { get; set; }

        public MovieDto(Entities.Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Genre = (Genre)movie.GenreId;
            NumberOfVotes = movie.MoviesClassification?.Count;
            Average = movie.MoviesClassification?.Sum(x => x.MovieScaleId) / NumberOfVotes;
            CastOfMovie = movie.CastOfMovies.Select(x => new CastOfMovieDto(x)).ToList();
        }
    }
}
