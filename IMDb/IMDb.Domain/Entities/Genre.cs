﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class Genre : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        private ICollection<Movie> _movies { get; set; }
        public virtual IReadOnlyCollection<Movie> Movies { get { return _movies as Collection<Movie>; } }

        public Genre()
        {
            _movies = new Collection<Movie>();
        }
    }
}