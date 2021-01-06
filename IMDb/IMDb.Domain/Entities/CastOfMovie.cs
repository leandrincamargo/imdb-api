using System;

namespace IMDb.Domain.Entities
{
    public class CastOfMovie : IIdentityEntity
    {
        public Guid Id { get; set; }

        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public Guid CastId { get; set; }
        public virtual Cast Cast { get; set; }
    }
}
