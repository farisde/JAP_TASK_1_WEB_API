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
    public class MediaService : IMediaService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MediaService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<PagedResponse<List<GetMediaDto>>> GetMedia(PaginationQuery paginationQuery = null)
        {
            var response = new PagedResponse<List<GetMediaDto>>();
            IQueryable<Media> dbMovies = _context.Medias
                                                 .Include(m => m.RatingList)
                                                 .Include(m => m.Cast)
                                                 .Where(m => m.MediaType == paginationQuery.MediaType)
                                                 .AsQueryable();
            if (paginationQuery == null)
            {
                paginationQuery = new PaginationQuery();
            }

            var skipAmount = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            var nextPageExists = dbMovies.Skip(paginationQuery.PageSize * paginationQuery.PageNumber)
                                         .Take(paginationQuery.PageSize)
                                         .Any();
            response.NextPage = nextPageExists ? paginationQuery.PageNumber + 1 : null;

            dbMovies = dbMovies.Skip(skipAmount)
                               .Take(paginationQuery.PageSize * paginationQuery.PageNumber);

            if (paginationQuery.PageNumber - 1 >= 1)
            {
                response.PreviousPage = paginationQuery.PageNumber - 1;
            }

            response.PageNumber = paginationQuery.PageNumber;
            response.PageSize = paginationQuery.PageSize;

            response.Data = dbMovies.OrderByDescending(m => m.Rating)
                                           .Select(m => _mapper.Map<GetMediaDto>(m))
                                           .ToList();
            return response;
        }

        public async Task<ServiceResponse<GetMediaDto>> GetMedia(int id)
        {
            var response = new ServiceResponse<GetMediaDto>();
            var dbMedia = await _context.Medias.Include(m => m.RatingList)
                                           .Include(m => m.Cast)
                                           .FirstOrDefaultAsync(m => m.Id == id);
            response.Data = _mapper.Map<GetMediaDto>(dbMedia);
            return response;
        }

        public async Task<ServiceResponse<List<GetMediaDto>>> GetSearchResults(SendSearchResultsDto query)
        {
            var response = new ServiceResponse<List<GetMediaDto>>();

            var dbMovies = _context.Medias
                .Include(m => m.RatingList)
                .Include(m => m.Cast)
                .AsQueryable();

            response.Data = await FilterSearchResults(dbMovies, query)
                                    .Select(m => _mapper.Map<GetMediaDto>(m))
                                    .ToListAsync();
            return response;
        }

        private IQueryable<Media> FilterSearchResults(IQueryable<Media> dbMovies, SendSearchResultsDto query)
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