using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class User : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }

        private ICollection<MovieClassification> _moviesClassification { get; set; }
        public virtual IReadOnlyCollection<MovieClassification> MoviesClassification { get { return _moviesClassification as Collection<MovieClassification>; } }

        public User()
        {
            _moviesClassification = new Collection<MovieClassification>();
        }
    }
}
