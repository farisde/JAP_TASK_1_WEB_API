using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using JAP_TASK_1_WEB_API.Data;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;
using JAP_TASK_1_WEB_API.Queries;
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

        public async Task<PagedResponse<List<GetMovieDto>>> GetMovies(PaginationQuery paginationQuery = null)
        {
            var serviceResponse = new PagedResponse<List<GetMovieDto>>();
            List<Movie> dbMovies = null;
            if (paginationQuery.PageNumber == 0)
            {
                dbMovies = await _context.Movies
                                .Include(m => m.RatingList)
                                .Include(m => m.Cast)
                                .ToListAsync();
            }
            else
            {
                dbMovies = await _context.Movies
                                .Include(m => m.RatingList)
                                .Include(m => m.Cast)
                                .Take(paginationQuery.PageSize * paginationQuery.PageNumber)
                                .ToListAsync();
            }

            if (paginationQuery.PageNumber >= 1)
            {
                var skipAmount = (paginationQuery.PageNumber) * paginationQuery.PageSize;
                var testMovies = await _context.Movies
                                .Include(m => m.RatingList)
                                .Include(m => m.Cast)
                                .Skip(skipAmount)
                                .Take(paginationQuery.PageSize * paginationQuery.PageNumber)
                                .ToListAsync();
                serviceResponse.NextPage = testMovies.Any() ? paginationQuery.PageNumber + 1 : null;
            }
            if (paginationQuery.PageNumber - 1 >= 1)
            {
                serviceResponse.PreviousPage = paginationQuery.PageNumber - 1;
            }
            serviceResponse.PageNumber = paginationQuery.PageNumber;
            serviceResponse.PageSize = paginationQuery.PageSize;

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

            //search phrases implementation
            var targetValue = GetNumberFromString(query.SearchPhrase);
            if (query.SearchPhrase.Contains("star"))
            {
                if (query.SearchPhrase.Contains("least"))
                {
                    dbMovies = dbMovies.Where(m => m.Rating >= targetValue).ToList();
                }
                else if (query.SearchPhrase.Contains("most"))
                {
                    dbMovies = dbMovies.Where(m => m.Rating < targetValue + 1).ToList();
                }
                else
                {
                    if (targetValue == 5)
                    {
                        dbMovies = dbMovies.Where(m => m.Rating.Equals(targetValue)).ToList();
                    }
                    else
                    {
                        dbMovies = dbMovies.Where(m => m.Rating.Equals(targetValue) ||
                                                        m.Rating > targetValue && m.Rating < targetValue + 1)
                                            .ToList();
                    }
                }
            }
            else if (query.SearchPhrase.Contains("after") || query.SearchPhrase.Contains("before"))
            {
                if (query.SearchPhrase.Contains("before"))
                {
                    dbMovies = dbMovies.Where(m => m.ReleaseDate.Year < targetValue).ToList();
                }
                else
                {
                    dbMovies = dbMovies.Where(m => m.ReleaseDate.Year > targetValue).ToList();
                }
            }
            else if (query.SearchPhrase.Contains("older"))
            {
                if (query.SearchPhrase.Contains("year"))
                {
                    dbMovies = dbMovies
                        .Where(m => m.ReleaseDate < DateTime.Now.AddYears(-1 * Convert.ToInt32(targetValue)))
                        .ToList();
                }
            }
            else
            {
                dbMovies = dbMovies
                .Where(m =>
                {
                    return m.Title.ToUpper().Contains(query.SearchPhrase.ToUpper()) ||
                            m.Description.ToUpper().Contains(query.SearchPhrase.ToUpper()) ||
                            m.Cast.Any(c => c.Name.ToUpper().Contains(query.SearchPhrase.ToUpper()));
                }).ToList();
            }



            response.Data = dbMovies.Select(m => _mapper.Map<GetMovieDto>(m)).ToList();
            response.Data = SortMoviesByRating(response.Data);

            return response;
        }

        private List<GetMovieDto> SortMoviesByRating(List<GetMovieDto> movies)
        {
            movies.Sort((m1, m2) => m2.Rating.CompareTo(m1.Rating));
            return movies;
        }

        private double GetNumberFromString(string phrase)
        {
            try
            {
                return Double.Parse(Regex.Match(phrase, @"\d+").Value);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}