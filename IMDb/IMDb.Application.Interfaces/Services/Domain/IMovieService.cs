using IMDb.Application.Interfaces.Services.Standard;
using IMDb.Domain.DTOs.Movie;
using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using System;
using System.Threading.Tasks;

namespace IMDb.Application.Interfaces.Services.Domain
{
    public interface IMovieService : IServiceBase<Movie>
    {
        Task AddMovieAsync(NewMovieDto dto);
        Task AddMovieClassificationAsync(NewMovieClassificationDto dto);
        Task AddCastAsync(NewCastDto dto);
        Task<MovieDto> GetMovieByIdAsync(Guid id);
        Task<Pagination<MovieDto>> GetMoviesAsync(MovieFilterDto dto, int pageNumber, int pageSize);
    }
}
