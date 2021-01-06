using IMDb.Domain.Entities;

namespace IMDb.Domain.DTOs.Movie
{
    public class NewCastDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Enums.CastType CastType { get; set; }

        public Cast DtoToEntity()
        {
            return new Cast
            {
                Name = Name,
                Age = Age,
                CastTypeId = (byte)this.CastType
            };
        }
    }
}
