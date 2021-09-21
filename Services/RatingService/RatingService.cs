using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieBuff.Data;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBuff.Services.MovieService;

namespace MovieBuff.Services.RatingService
{
    public class RatingService : IRatingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RatingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetMovieDto>>> AddMovieRating(AddRatingDto newRating)
        {
            var response = new ServiceResponse<List<GetMovieDto>>();
            var ratedMovie = await _context.Movies
                .Include(m => m.Cast)
                .Include(m => m.RatingList)
                .FirstOrDefaultAsync(m => m.Id == newRating.RatedMovieId);
            var rating = new Rating
            {
                Value = newRating.Value,
                RatedMovie = ratedMovie,
                RatedMovieId = newRating.RatedMovieId
            };
            _context.Ratings.Add(rating);

            ratedMovie.Rating = ratedMovie.RatingList.Average(r => r.Value);

            _context.Movies.Update(ratedMovie);
            await _context.SaveChangesAsync();

            var dbMovies = await _context.Movies
                    .Include(m => m.Cast)
                    .Include(m => m.RatingList)
                    .ToListAsync();

            response.Data = dbMovies.Select(m => _mapper.Map<GetMovieDto>(m)).ToList();
            response.Data = SortMoviesByRating(response.Data);
            return response;
        }

        private List<GetMovieDto> SortMoviesByRating(List<GetMovieDto> movies)
        {
            movies.Sort((m1, m2) => m2.Rating.CompareTo(m1.Rating));
            return movies;
        }
    }
}
