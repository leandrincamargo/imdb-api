using IMDb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDb.Domain.DTOs.Movie
{
    public class NewMovieDto
    {
        [Required(ErrorMessage = "The {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public Genre Genre { get; set; }
        public DateTime MovieRelease { get; set; }
        public bool Status { get; set; }

        public List<Guid> CastIds { get; set; }

        public Entities.Movie DtoToEntity()
        {
            return new Entities.Movie
            {
                Name = Name,
                GenreId = (byte)Genre,
                MovieRelease = MovieRelease,
                Status = Status
            };
        }
    }
}
