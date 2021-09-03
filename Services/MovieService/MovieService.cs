using System.Collections.Generic;
using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;

namespace JAP_TASK_1_WEB_API.Services.MovieService
{
    public class MovieService : IMovieService
    {
        public async Task<ServiceResponse<List<GetMovieDto>>> GetMovies()
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();



            return serviceResponse;
        }
    }
}