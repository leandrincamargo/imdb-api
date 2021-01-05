using System;

namespace IMDb.Domain.Entities
{
    public class ActorMovie : IIdentityEntity
    {
        public Guid Id { get; set; }

        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public Guid ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
