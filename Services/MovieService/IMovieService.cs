using System.Collections.Generic;
using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;

namespace JAP_TASK_1_WEB_API.Services.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<GetMovieDto>>> GetMovies();
        Task<ServiceResponse<List<GetMovieDto>>> AddMovieRating(AddRatingDto newRating);

        Task<ServiceResponse<List<GetMovieDto>>> GetSearchResults(SendSearchResultsDto query);
    }
}