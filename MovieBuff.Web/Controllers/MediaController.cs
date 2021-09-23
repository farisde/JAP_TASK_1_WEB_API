using Microsoft.AspNetCore.Mvc;
using MovieBuff.Core.Services.MediaService;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBuff.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _movieService;

        public MediaController(IMediaService movieService)
        {
            _movieService = movieService;

        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<GetMediaDto>>>> GetMedia([FromQuery] PaginationQuery paginationQuery = null)
        {
            var response = await _movieService.GetMedia(paginationQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagedResponse<List<GetMediaDto>>>> GetMedia(int id)
        {
            var response = await _movieService.GetMedia(id);
            return Ok(response);
        }
    }
}