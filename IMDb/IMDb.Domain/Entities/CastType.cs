using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMDb.Domain.Entities
{
    public class CastType
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        private ICollection<Cast> _casts { get; set; }
        public virtual IReadOnlyCollection<Cast> Casts { get { return _casts as Collection<Cast>; } }

        public CastType()
        {
            _casts = new Collection<Cast>();
        }
    }
}
