using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class Cast : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public byte CastTypeId { get; set; }
        public virtual CastType CastType {get;set;}

        private ICollection<CastOfMovie> _castOfMovies { get; set; }
        public virtual IReadOnlyCollection<CastOfMovie> CastOfMovies { get { return _castOfMovies as Collection<CastOfMovie>; } }

        public Cast()
        {
            _castOfMovies = new Collection<CastOfMovie>();
        }
    }
}
