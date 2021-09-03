using System.Collections.Generic;
using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;
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
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> GetAllMovies()
        {
            var serviceResponse = await _movieService.GetMovies();
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