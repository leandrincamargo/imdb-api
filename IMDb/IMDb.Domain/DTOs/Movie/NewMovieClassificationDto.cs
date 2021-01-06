using IMDb.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMDb.Domain.DTOs.Movie
{
    public class NewMovieClassificationDto
    {
        [Required(ErrorMessage = "The {0} is required")]
        [Range(0, 4, ErrorMessage = "The vote must be between 0 and 4!")]
        public Enums.MovieScale Vote { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public Guid MovieId { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }

        public MovieClassification DtoToEntity()
        {
            return new MovieClassification
            {
                MovieScaleId = (byte)Vote,
                MovieId = MovieId,
                UserId = UserId
            };
        }
    }
}
