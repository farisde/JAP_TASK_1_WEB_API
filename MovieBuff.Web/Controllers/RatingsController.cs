using Microsoft.AspNetCore.Mvc;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Services.RatingService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBuff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMediaDto>>>> AddMovieRating(AddRatingDto newRating)
        {
            var response = await _ratingService.AddMovieRating(newRating);
            return Ok(response);
        }
    }
}
