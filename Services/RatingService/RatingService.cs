using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieBuff.Data;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ServiceResponse<GetRatingDto>> AddMovieRating(AddRatingDto newRating)
        {
            var response = new ServiceResponse<GetRatingDto>();
            var ratedMovie = await _context.Medias
                .Include(m => m.Cast)
                .Include(m => m.RatingList)
                .FirstOrDefaultAsync(m => m.Id == newRating.RatedMediaId);
            var rating = new Rating
            {
                Value = newRating.Value,
                RatedMedia = ratedMovie,
                RatedMediaId = newRating.RatedMediaId
            };
            _context.Ratings.Add(rating);

            ratedMovie.Rating = ratedMovie.RatingList.Average(r => r.Value);

            _context.Medias.Update(ratedMovie);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetRatingDto>(rating);
            return response;
        }
    }
}
