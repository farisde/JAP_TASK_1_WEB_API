using System;
using System.Collections.Generic;
using JAP_TASK_1_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JAP_TASK_1_WEB_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cm1 = new CastMember { Id = 1, Name = "Carrie Fisher" };
            var cm2 = new CastMember { Id = 2, Name = "Mark Hamil" };
            var cm3 = new CastMember { Id = 3, Name = "Harrison Ford" };
            var cm4 = new CastMember { Id = 4, Name = "Cole Sprouse" };
            var cm5 = new CastMember { Id = 5, Name = "Lili Reinhart" };
            var cm6 = new CastMember { Id = 6, Name = "Camila Mendes" };
            var cm7 = new CastMember { Id = 7, Name = "KJ Apa" };
            var cm8 = new CastMember { Id = 8, Name = "James Spader" };
            var cm9 = new CastMember { Id = 9, Name = "Megan Boone" };
            var cm10 = new CastMember { Id = 10, Name = "Diego Klattenhoff" };
            var cm11 = new CastMember { Id = 11, Name = "Henry Lennix" };

            var m1 = new Movie
            {
                Id = 1,
                Title = "Star Wars: A New Hope (Episode IV)",
                Description = "After Princess Leia, the leader of the Rebel Alliance, is held hostage by Darth Vader, Luke and Han Solo must free her and destroy the powerful weapon created by the Galactic Empire.",
                ReleaseDate = new DateTime(1997, 5, 25),
                CoverImage = "https://kbimages1-a.akamaihd.net/538b1473-6d45-47f4-b16e-32a0a6ba7f9a/1200/1200/False/star-wars-episode-iv-a-new-hope-3.jpg",
                Rating = 5,
                IsMovie = true
            };

            var m2 = new Movie
            {
                Id = 2,
                Title = "Star Wars: The Empire Strikes Back (Episode V)",
                Description = "Darth Vader is adamant about turning Luke Skywalker to the dark side. Master Yoda trains Luke to become a Jedi Knight while his friends try to fend off the Imperial fleet.",
                ReleaseDate = new DateTime(1980, 5, 21),
                CoverImage = "https://images.penguinrandomhouse.com/cover/9780345320223",
                Rating = 4.8,
                IsMovie = true
            };

            var m3 = new Movie
            {
                Id = 3,
                Title = "Riverdale",
                Description = "Archie, Betty, Jughead and Veronica tackle being teenagers in a town that is rife with sinister happenings and blood-thirsty criminals.",
                ReleaseDate = new DateTime(2017, 1, 26),
                CoverImage = "https://static.wikia.nocookie.net/riverdalearchie/images/3/3a/Season_2_Poster.jpg",
                Rating = 4.5,
                IsMovie = false
            };

            var m4 = new Movie
            {
                Id = 4,
                Title = "The Blacklist",
                Description = "A wanted fugitive mysteriously surrenders himself to the FBI and offers to help them capture deadly criminals. His sole condition is that he will work only with the new profiler, Elizabeth Keen.",
                ReleaseDate = new DateTime(2013, 9, 23),
                CoverImage = "https://static.wikia.nocookie.net/blacklist/images/5/57/Season_7_Poster.jpg",
                Rating = 5,
                IsMovie = false
            };

            var r1 = new Rating { Id = 1, Value = 5, RatedMovieId = m1.Id };
            var r2 = new Rating { Id = 2, Value = 4.8, RatedMovieId = m2.Id };
            var r3 = new Rating { Id = 3, Value = 4.5, RatedMovieId = m3.Id };
            var r4 = new Rating { Id = 4, Value = 5, RatedMovieId = m4.Id };


            modelBuilder.Entity<CastMember>().HasData(
                cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8, cm9, cm10, cm11
            );

            modelBuilder.Entity<Movie>().HasData(
                m1, m2, m3, m4
            );

            modelBuilder.Entity<Rating>().HasData(
                r1, r2, r3, r4
            );
        }
    }
}