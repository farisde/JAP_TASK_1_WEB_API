﻿using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBuff.Services.RatingService
{
    public interface IRatingService
    {
        Task<ServiceResponse<List<GetMovieDto>>> AddMovieRating(AddRatingDto newRating);
    }
}
