using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using MovieBuff.Services.MovieService;
using Microsoft.AspNetCore.Mvc;

namespace MovieBuff.Controllers
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
            int nullUserId = -1;
            var serviceResponse = new PagedResponse<List<GetMovieDto>>();
            if (User.Claims.Any())
            {
                int.TryParse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value, out int userId);
                serviceResponse = await _movieService.GetMovies(userId, paginationQuery);
            }
            else
            {
                serviceResponse = await _movieService.GetMovies(nullUserId, paginationQuery);
            }

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