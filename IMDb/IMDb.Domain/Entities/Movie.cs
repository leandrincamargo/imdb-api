using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Domain.Entities
{
    public class Movie : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime MovieRelease { get; set; }
        public virtual Genre Genres { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public decimal Media { get; set; }

        private ICollection<ActorMovie> _actorsMovie { get; set; }
        public virtual IReadOnlyCollection<ActorMovie> ActorsMovie { get { return _actorsMovie as Collection<ActorMovie>; } }

        private ICollection<MovieClassification> _moviesClassification { get; set; }
        public virtual IReadOnlyCollection<MovieClassification> MoviesClassification { get { return _moviesClassification as Collection<MovieClassification>; } }

        public Movie()
        {
            _actorsMovie = new Collection<ActorMovie>();
            _moviesClassification = new Collection<MovieClassification>();
        }
    }
}
