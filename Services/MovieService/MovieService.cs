using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JAP_TASK_1_WEB_API.Data;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JAP_TASK_1_WEB_API.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MovieService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<ServiceResponse<List<GetMovieDto>>> GetMovies()
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();

            var dbMmovies = await _context.Movies
                .Include(m => m.RatingList)
                .Include(m => m.Cast)
                .ToListAsync();

            serviceResponse.Data = dbMmovies.Select(m => _mapper.Map<GetMovieDto>(m)).ToList();
            return serviceResponse;
        }
    }
}