using System;
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

        public async Task<ServiceResponse<List<GetMovieDto>>> GetMovies()
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();

            var dbMovies = await _context.Movies
                .Include(m => m.RatingList)
                .Include(m => m.Cast)
                .ToListAsync();

            serviceResponse.Data = dbMovies.Select(m => _mapper.Map<GetMovieDto>(m)).ToList();
            serviceResponse.Data = SortMoviesByRating(serviceResponse.Data);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMovieDto>>> GetSearchResults(SendSearchResultsDto query)
        {
            var response = new ServiceResponse<List<GetMovieDto>>();

            var dbMovies = await _context.Movies
                .Include(m => m.RatingList)
                .Include(m => m.Cast)
                .ToListAsync();
            dbMovies = dbMovies
                .Where(m =>
                {
                    return m.Title.ToUpper().Contains(query.SearchPhrase.ToUpper()) ||
                            m.Description.ToUpper().Contains(query.SearchPhrase.ToUpper()) ||
                            m.Cast.Any(c => c.Name.ToUpper().Contains(query.SearchPhrase.ToUpper()));
                }).ToList();

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