using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBuff.Services.MovieService
{
    public interface IMovieService
    {
        Task<PagedResponse<List<GetMovieDto>>> GetMovies(PaginationQuery paginationQuery = null);
        Task<ServiceResponse<List<GetMovieDto>>> GetSearchResults(SendSearchResultsDto query);
    }
}