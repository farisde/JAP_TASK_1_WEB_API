using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBuff.Services.MovieService
{
    public interface IMediaService
    {
        Task<PagedResponse<List<GetMediaDto>>> GetMedia(PaginationQuery paginationQuery = null);
        /*Task<ServiceResponse<List<GetMediaDto>>> GetSearchResults(SendSearchQueryDto query);*/
        Task<ServiceResponse<GetMediaDto>> GetMedia(int id);
    }
}