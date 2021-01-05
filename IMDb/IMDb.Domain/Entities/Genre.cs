using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        private ICollection<Movie> _movies { get; set; }
        public virtual IReadOnlyCollection<Movie> Movies { get { return _movies as Collection<Movie>; } }

        public Genre()
        {
            _movies = new Collection<Movie>();
        }
    }
}
