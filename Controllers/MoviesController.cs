using Microsoft.AspNetCore.Mvc;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using MovieBuff.Services.MovieService;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieBuff.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;

        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<GetMovieDto>>>> GetMovies([FromQuery] PaginationQuery paginationQuery = null)
        {
            var response = await _movieService.GetMovies(paginationQuery);
            return Ok(response);
        }

        [HttpPost("sendSearchQuery")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> GetSearchResults(SendSearchResultsDto query)
        {
            var serviceResponse = await _movieService.GetSearchResults(query);
            return Ok(serviceResponse);
        }
    }
}