using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;

namespace MovieBuff.Services.MovieService
{
    public interface IMovieService
    {
        Task<PagedResponse<List<GetMovieDto>>> GetMovies(int userId, PaginationQuery paginationQuery = null);
        Task<ServiceResponse<List<GetMovieDto>>> AddMovieRating(AddRatingDto newRating);

        Task<ServiceResponse<List<GetMovieDto>>> GetSearchResults(SendSearchResultsDto query);
    }
}