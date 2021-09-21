using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieBuff.Data;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using MovieBuff.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieBuff.Services.MovieService
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

            serviceResponse.Data = dbMovies.OrderByDescending(m => m.Rating)
                                           .Select(m => _mapper.Map<GetMovieDto>(m))
                                           .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMovieDto>>> GetSearchResults(SendSearchResultsDto query)
        {
            var response = new ServiceResponse<List<GetMovieDto>>();

            var dbMovies = _context.Movies
                .Include(m => m.RatingList)
                .Include(m => m.Cast)
                .AsQueryable();

            response.Data = await FilterSearchResults(dbMovies, query)
                                    .Select(m => _mapper.Map<GetMovieDto>(m))
                                    .ToListAsync();
            return response;
        }

        private IQueryable<Movie> FilterSearchResults(IQueryable<Movie> dbMovies, SendSearchResultsDto query)
        {
            var targetValue = GetNumberFromString(query.SearchPhrase);
            if (query.SearchPhrase.Contains("star") && targetValue != -1)
            {
                if (query.SearchPhrase.Contains("least"))
                {
                    dbMovies = dbMovies.Where(m => m.Rating >= targetValue);
                }
                else if (query.SearchPhrase.Contains("most"))
                {
                    dbMovies = dbMovies.Where(m => m.Rating < targetValue + 1);
                }
                else
                {
                    if (targetValue == 5)
                    {
                        dbMovies = dbMovies.Where(m => m.Rating.Equals(targetValue));
                    }
                    else
                    {
                        dbMovies = dbMovies.Where(m => m.Rating.Equals(targetValue) ||
                                                        m.Rating > targetValue && m.Rating < targetValue + 1);
                    }
                }
            }
            else if (query.SearchPhrase.Contains("after") || query.SearchPhrase.Contains("before"))
            {
                if (query.SearchPhrase.Contains("before"))
                {
                    dbMovies = dbMovies.Where(m => m.ReleaseDate.Year < targetValue);
                }
                else
                {
                    dbMovies = dbMovies.Where(m => m.ReleaseDate.Year > targetValue);
                }
            }
            else if (query.SearchPhrase.Contains("older"))
            {
                if (query.SearchPhrase.Contains("year"))
                {
                    dbMovies = dbMovies
                        .Where(m => m.ReleaseDate < DateTime.Now.AddYears(-1 * Convert.ToInt32(targetValue)));
                }
            }
            else
            {
                dbMovies = dbMovies
                .Where(m =>
                    m.Title.ToUpper().Contains(query.SearchPhrase.ToUpper()) ||
                    m.Description.ToUpper().Contains(query.SearchPhrase.ToUpper()) ||
                    m.Cast.Any(c => c.Name.ToUpper().Contains(query.SearchPhrase.ToUpper()))
                );
            }
            return dbMovies.OrderByDescending(m => m.Rating);
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