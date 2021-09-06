using System.Collections.Generic;
using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;
using JAP_TASK_1_WEB_API.Queries;

namespace JAP_TASK_1_WEB_API.Services.MovieService
{
    public interface IMovieService
    {
        Task<PagedResponse<List<GetMovieDto>>> GetMovies(PaginationQuery paginationQuery = null);
        Task<ServiceResponse<List<GetMovieDto>>> AddMovieRating(AddRatingDto newRating);

        Task<ServiceResponse<List<GetMovieDto>>> GetSearchResults(SendSearchResultsDto query);
    }
}