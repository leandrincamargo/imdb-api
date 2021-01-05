using System;

namespace IMDb.Domain.Entities
{
    public class MovieClassification : IIdentityEntity
    {
        public Guid Id { get; set; }

        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual MovieScale Vote { get; set; }
    }
}
