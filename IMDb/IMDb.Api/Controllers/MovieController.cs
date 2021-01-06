using IMDb.Application.Interfaces.Services.Domain;
using IMDb.Domain.DTOs.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Authorize(Roles = "41361f47-53bf-4084-965f-cabc95532565")]
        [Route("Add")]
        public async Task<IActionResult> AddMovieAsync([FromBody] NewMovieDto dto)
        {
            var errors = GetErrorListFromModelState();
            if (errors.Any())
                return BadRequest(errors);

            await _movieService.AddMovieAsync(dto);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "41361f47-53bf-4084-965f-cabc95532565")]
        [Route("Cast")]
        public async Task<IActionResult> AddCast([FromBody] NewCastDto dto)
        {
            var errors = GetErrorListFromModelState();
            if (errors.Any())
                return BadRequest(errors);

            await _movieService.AddCastAsync(dto);
            return Ok();
        }

        [HttpPost]
        [Route("Classification")]
        //[Authorize(Roles = "5c646334-7f35-43f5-9a84-17a654fbdb32")]
        [Authorize]
        public async Task<IActionResult> AddMovieClassificationAssync([FromBody] NewMovieClassificationDto dto)
        {
            var errors = GetErrorListFromModelState();
            if (errors.Any())
                return BadRequest(errors);

            var claims = ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.ToList();
            dto.UserId = Guid.Parse(claims.FirstOrDefault(a => a.Type == System.Security.Claims.ClaimTypes.Name).Value);

            await _movieService.AddMovieClassificationAsync(dto);
            return Ok();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMovieByIdAsync(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            return Ok(movie);
        }

        [HttpPost]
        [Route("moviesByFilters")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMovieByFilters([FromBody] MovieFilterDto dto, int pageNumber = 1, int pageSize = 10)
        {
            var movies = await _movieService.GetMoviesAsync(dto, pageNumber, pageSize);
            return Ok(movies);
        }
    }
}
