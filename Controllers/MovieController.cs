using System.Collections.Generic;
using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;
using JAP_TASK_1_WEB_API.Queries;
using JAP_TASK_1_WEB_API.Services.MovieService;
using Microsoft.AspNetCore.Mvc;

namespace JAP_TASK_1_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }

        [HttpGet("AllMovies")]
        public async Task<ActionResult<PagedResponse<List<GetMovieDto>>>> GetAllMovies([FromQuery] PaginationQuery paginationQuery = null)
        {
            var serviceResponse = await _movieService.GetMovies(paginationQuery);
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }
            else
            {
                return BadRequest(serviceResponse);
                //HANDLE NEKIH POTENCIJALNIH ERRORA. URADI KASNIJE!
            }
        }

        [HttpPost("AddMovieRating")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> AddMovieRating(AddRatingDto newRating)
        {
            var response = await _movieService.AddMovieRating(newRating);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
                //HANDLE NEKIH POTENCIJALNIH ERRORA. URADI KASNIJE!
            }
        }

        [HttpPost("SendSearchResults")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> GetSearchResults(SendSearchResultsDto query)
        {
            var serviceResponse = await _movieService.GetSearchResults(query);
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }
            else
            {
                return BadRequest(serviceResponse);
                //HANDLE NEKIH POTENCIJALNIH ERRORA. URADI KASNIJE!
            }
        }
    }
}