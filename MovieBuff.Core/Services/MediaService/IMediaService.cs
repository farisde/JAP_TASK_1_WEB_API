using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBuff.Core.Services.MediaService
{
    public interface IMediaService
    {
        Task<PagedResponse<List<GetMediaDto>>> GetMedia(PaginationQuery paginationQuery = null);
        Task<ServiceResponse<GetMediaDto>> GetMedia(int id);
    }
}