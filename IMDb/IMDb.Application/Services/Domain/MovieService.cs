using IMDb.Application.Interfaces.Services.Domain;
using IMDb.Application.Services.Standard;
using IMDb.Domain.DTOs.Movie;
using IMDb.Domain.Entities;
using IMDb.Domain.Utility;
using IMDb.Infraestructure.Interfaces.Repositories.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Application.Services.Domain
{
    public class MovieService : ServiceBase<Movie>, IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMovieClassificationRepository _movieClassificationrepository;
        private readonly ICastOfMovieRepository _castOfMovieRepository;
        private readonly ICastRepository _castRepository;

        public MovieService(IMovieRepository repository, IMovieClassificationRepository movieClassificationrepository,
            ICastOfMovieRepository castOfMovieRepository, ICastRepository castRepository) : base(repository)
        {
            _repository = repository;
            _movieClassificationrepository = movieClassificationrepository;
            _castOfMovieRepository = castOfMovieRepository;
            _castRepository = castRepository;
        }

        public async Task AddCastAsync(NewCastDto dto)
        {
            var newCast = dto.DtoToEntity();
            await _castRepository.AddAsync(newCast);
        }

        public async Task AddMovieAsync(NewMovieDto dto)
        {
            var newMovie = dto.DtoToEntity();
            await _repository.AddAsync(newMovie);
            foreach (var item in dto.CastIds)
                await _castOfMovieRepository.AddAsync(new CastOfMovie { CastId = item, MovieId = newMovie.Id });
        }

        public async Task AddMovieClassificationAsync(NewMovieClassificationDto dto)
        {
            var newMovie = dto.DtoToEntity();
            await _movieClassificationrepository.AddAsync(newMovie);
        }

        public async Task<MovieDto> GetMovieByIdAsync(Guid id)
        {
            var movie = await _repository.GetByIdIncludingCastAsync(id);
            return new MovieDto(movie);
        }

        public async Task<Pagination<MovieDto>> GetMoviesAsync(MovieFilterDto dto, int pageNumber, int pageSize)
        {
            Pagination<Movie> moviePagination;
            moviePagination = await _repository.GetIncludingCastWithPaginationAsync(null, pageNumber, pageSize);

            return new Pagination<MovieDto>(moviePagination.Items.Select(x => new MovieDto(x)), moviePagination.TotalItemCount, moviePagination.PageSize, moviePagination.CurrentPage);
        }
    }
}
