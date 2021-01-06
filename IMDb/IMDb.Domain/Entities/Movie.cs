using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class Movie : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime MovieRelease { get; set; }
        public bool Status { get; set; }

        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        private ICollection<CastOfMovie> _castOfMovies { get; set; }
        public virtual IReadOnlyCollection<CastOfMovie> CastOfMovies { get { return _castOfMovies as Collection<CastOfMovie>; } }

        private ICollection<MovieClassification> _moviesClassification { get; set; }
        public virtual IReadOnlyCollection<MovieClassification> MoviesClassification { get { return _moviesClassification as Collection<MovieClassification>; } }

        public Movie()
        {
            _castOfMovies = new Collection<CastOfMovie>();
            _moviesClassification = new Collection<MovieClassification>();
        }
    }
}
