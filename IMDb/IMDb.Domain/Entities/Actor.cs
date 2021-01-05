using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class Actor : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private ICollection<ActorMovie> _actorMovies { get; set; }
        public virtual IReadOnlyCollection<ActorMovie> ActorMovies { get { return _actorMovies as Collection<ActorMovie>; } }

        public Actor()
        {
            _actorMovies = new Collection<ActorMovie>();
        }
    }
}
