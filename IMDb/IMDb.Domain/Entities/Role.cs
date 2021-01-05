using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class Role : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        private ICollection<User> _users { get; set; }
        public virtual IReadOnlyCollection<User> Users { get { return _users as Collection<User>; } }

        public Role()
        {
            _users = new Collection<User>();
        }
    }
}
