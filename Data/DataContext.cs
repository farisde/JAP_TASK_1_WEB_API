using Microsoft.EntityFrameworkCore;
using MovieBuff.Models;
using System;

namespace MovieBuff.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Media> Medias { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CastMembers
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
            var cm12 = new CastMember { Id = 12, Name = "Daisy Ridley" };
            var cm13 = new CastMember { Id = 13, Name = "Adam Driver" };
            var cm14 = new CastMember { Id = 14, Name = "Natalie Portman" };
            var cm15 = new CastMember { Id = 15, Name = "Ewan McGregor" };
            var cm16 = new CastMember { Id = 16, Name = "Liam Neeson" };
            var cm17 = new CastMember { Id = 17, Name = "Hayden Christensen" };

            var cm18 = new CastMember { Id = 18, Name = "Jared Harris" };
            var cm19 = new CastMember { Id = 19, Name = "Stellan Skarsgård" };
            var cm20 = new CastMember { Id = 20, Name = "Emily Watson" };
            var cm21 = new CastMember { Id = 21, Name = "Paul Ritter" };

            var cm22 = new CastMember { Id = 22, Name = "Úrsula Corberó" };
            var cm23 = new CastMember { Id = 23, Name = "Álvaro Morte" };
            var cm24 = new CastMember { Id = 24, Name = "Itziar Ituño" };
            var cm25 = new CastMember { Id = 25, Name = "Miguel Herrán" };

            var cm26 = new CastMember { Id = 26, Name = "Sofía Vergara" };
            var cm27 = new CastMember { Id = 27, Name = "Eric Stonestreet" };
            var cm28 = new CastMember { Id = 28, Name = "Julie Bowen" };
            var cm29 = new CastMember { Id = 29, Name = "Sarah Hyland" };

            var cm30 = new CastMember { Id = 30, Name = "Pedro Pascal" };
            var cm31 = new CastMember { Id = 31, Name = "Gina Carano" };
            var cm32 = new CastMember { Id = 32, Name = "Giancarlo Esposito" };
            var cm33 = new CastMember { Id = 33, Name = "Carl Weathers" };

            var cm34 = new CastMember { Id = 34, Name = "Daniel Radcliffe" };
            var cm35 = new CastMember { Id = 35, Name = "Emma Watson" };
            var cm36 = new CastMember { Id = 36, Name = "Rupert Grint" };

            var cm37 = new CastMember { Id = 37, Name = "Chloe Bennet" };
            var cm38 = new CastMember { Id = 38, Name = "Elizabeth Henstridge" };
            var cm39 = new CastMember { Id = 39, Name = "Ming‑Na Wen" };

            var cm40 = new CastMember { Id = 40, Name = "Emma Thompson" };
            var cm41 = new CastMember { Id = 41, Name = "Russell Tovey" };
            var cm42 = new CastMember { Id = 42, Name = "Ruth Madeley" };

            var cm43 = new CastMember { Id = 43, Name = "Lucas Till" };
            var cm44 = new CastMember { Id = 44, Name = "Tristin Mays" };
            var cm45 = new CastMember { Id = 45, Name = "Meredith Eaton" };

            var cm46 = new CastMember { Id = 46, Name = "Ellen Pompeo" };
            var cm47 = new CastMember { Id = 47, Name = "Chandra Wilson" };
            var cm48 = new CastMember { Id = 48, Name = "James Pickens Jr." };

            var cm49 = new CastMember { Id = 49, Name = "Zendaya" };
            var cm50 = new CastMember { Id = 50, Name = "Hunter Schafer" };
            var cm51 = new CastMember { Id = 51, Name = "Jacob Elordi" };

            var cm52 = new CastMember { Id = 52, Name = "Henry Cavil" };
            var cm53 = new CastMember { Id = 53, Name = "Anya Chalotra" };
            var cm54 = new CastMember { Id = 54, Name = "Freya Allan" };

            var cm55 = new CastMember { Id = 55, Name = "Kiernan Shipka" };
            var cm56 = new CastMember { Id = 56, Name = "Ross Lynch" };
            var cm57 = new CastMember { Id = 57, Name = "Gavin Leatherwood" };

            var cm58 = new CastMember { Id = 58, Name = "Zoe Saldana" };
            var cm59 = new CastMember { Id = 59, Name = "Sam Worthington" };
            var cm60 = new CastMember { Id = 60, Name = "Sigourney Weaver" };
            #endregion

            #region Media
            var m1 = new Media
            {
                Id = 1,
                Title = "Star Wars: A New Hope (Episode IV)",
                Description = "After Princess Leia, the leader of the Rebel Alliance, is held hostage by Darth Vader, Luke and Han Solo must free her and destroy the powerful weapon created by the Galactic Empire.",
                ReleaseDate = new DateTime(1997, 5, 25),
                CoverImage = "https://kbimages1-a.akamaihd.net/538b1473-6d45-47f4-b16e-32a0a6ba7f9a/1200/1200/False/star-wars-episode-iv-a-new-hope-3.jpg",
                Rating = 5,
                MediaType = MediaType.Movie
            };

            var m2 = new Media
            {
                Id = 2,
                Title = "Star Wars: The Empire Strikes Back (Episode V)",
                Description = "Darth Vader is adamant about turning Luke Skywalker to the dark side. Master Yoda trains Luke to become a Jedi Knight while his friends try to fend off the Imperial fleet.",
                ReleaseDate = new DateTime(1980, 5, 21),
                CoverImage = "https://images.penguinrandomhouse.com/cover/9780345320223",
                Rating = 4.8,
                MediaType = MediaType.Movie
            };

            var m3 = new Media
            {
                Id = 3,
                Title = "Riverdale",
                Description = "Archie, Betty, Jughead and Veronica tackle being teenagers in a town that is rife with sinister happenings and blood-thirsty criminals.",
                ReleaseDate = new DateTime(2017, 1, 26),
                CoverImage = "https://static.wikia.nocookie.net/riverdalearchie/images/3/3a/Season_2_Poster.jpg",
                Rating = 4.5,
                MediaType = MediaType.TvShow
            };

            var m4 = new Media
            {
                Id = 4,
                Title = "The Blacklist",
                Description = "A wanted fugitive mysteriously surrenders himself to the FBI and offers to help them capture deadly criminals. His sole condition is that he will work only with the new profiler, Elizabeth Keen.",
                ReleaseDate = new DateTime(2013, 9, 23),
                CoverImage = "https://static.wikia.nocookie.net/blacklist/images/5/57/Season_7_Poster.jpg",
                Rating = 5,
                MediaType = MediaType.TvShow
            };

            var m5 = new Media
            {
                Id = 5,
                Title = "Star Wars: Return of the Jedi (Episode VI)",
                Description = "Luke Skywalker attempts to bring his father back to the light side of the Force. At the same time, the rebels hatch a plan to destroy the second Death Star.",
                ReleaseDate = new DateTime(1983, 5, 25),
                CoverImage = "https://m.media-amazon.com/images/I/91LlN7J+Z9L._SL1500_.jpg",
                Rating = 4.9,
                MediaType = MediaType.Movie
            };

            var m6 = new Media
            {
                Id = 6,
                Title = "Star Wars: The Force Awakens (Episode VII)",
                Description = "A new order threatens to destroy the New Republic. Finn, Rey and Poe, backed by the Resistance and the Republic, must find a way to stop them and find Luke, the last surviving Jedi.",
                ReleaseDate = new DateTime(2015, 11, 17),
                CoverImage = "https://m.media-amazon.com/images/M/MV5BOTAzODEzNDAzMl5BMl5BanBnXkFtZTgwMDU1MTgzNzE@._V1_.jpg",
                Rating = 4.5,
                MediaType = MediaType.Movie
            };

            var m7 = new Media
            {
                Id = 7,
                Title = "Star Wars: The Last Jedi (Episode VIII)",
                Description = "Rey seeks to learn the ways of the Jedi under Luke Skywalker, its remaining member, to reinvigorate the Resistance's war against the First Order.",
                ReleaseDate = new DateTime(2017, 11, 15),
                CoverImage = "https://i.pinimg.com/originals/f4/5a/ea/f45aea75f65c0feb5cbe168f17a9a087.jpg",
                Rating = 4.9,
                MediaType = MediaType.Movie
            };

            var m8 = new Media
            {
                Id = 8,
                Title = "Star Wars: The Rise of Skywalker (Episode IX)",
                Description = "The revival of Emperor Palpatine resurrects the battle between the Resistance and the First Order while the Jedi's legendary conflict with the Sith Lord comes to a head.",
                ReleaseDate = new DateTime(2019, 11, 20),
                CoverImage = "https://lumiere-a.akamaihd.net/v1/images/star-wars-the-rise-of-skywalker-theatrical-poster-1000_ebc74357.jpeg?region=0%2C0%2C891%2C1372",
                Rating = 4,
                MediaType = MediaType.Movie
            };

            var m9 = new Media
            {
                Id = 9,
                Title = "Star Wars: The Phantom Menace (Episode I)",
                Description = "Jedi Knights Qui-Gon Jinn and Obi-Wan Kenobi set out to stop the Trade Federation from invading Naboo. While travelling, they come across a gifted boy, Anakin, and learn that the Sith have returned.",
                ReleaseDate = new DateTime(1999, 4, 19),
                CoverImage = "https://play-lh.googleusercontent.com/sR1pzOxnF50WLR3vUqXYFvY01_tLD4XPn1RDHf0Xh-W04Vek_3iiZ98U7Db2JcmrqS8",
                Rating = 3.5,
                MediaType = MediaType.Movie
            };

            var m10 = new Media
            {
                Id = 10,
                Title = "Star Wars: Attack of the Clones (Episode II)",
                Description = "While pursuing an assassin, Obi Wan uncovers a sinister plot to destroy the Republic. With the fate of the galaxy hanging in the balance, the Jedi must defend the galaxy against the evil Sith.",
                ReleaseDate = new DateTime(2002, 4, 16),
                CoverImage = "https://m.media-amazon.com/images/M/MV5BMDAzM2M0Y2UtZjRmZi00MzVlLTg4MjEtOTE3NzU5ZDVlMTU5XkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_.jpg",
                Rating = 3.8,
                MediaType = MediaType.Movie
            };

            var m11 = new Media
            {
                Id = 11,
                Title = "Star Wars: Revenge of the Sith (Episode III)",
                Description = "Anakin joins forces with Obi-Wan and sets Palpatine free from the evil clutches of Count Doku. However, he falls prey to Palpatine and the Jedis' mind games and gives into temptation.",
                ReleaseDate = new DateTime(2005, 4, 19),
                CoverImage = "https://play-lh.googleusercontent.com/mMyoXM8bf72KK-Udap4-hAvqqdXgn0AIBXkS8zejT0RXITIh8oK9a-SYIVk89CA0rHJi",
                Rating = 4.2,
                MediaType = MediaType.Movie
            };

            var m12 = new Media
            {
                Id = 12,
                Title = "Avatar",
                Description = "Jake, who is paraplegic, replaces his twin on the Na'vi inhabited Pandora for a corporate mission. After the natives accept him as one of their own, he must decide where his loyalties lie.",
                ReleaseDate = new DateTime(2009, 11, 17),
                CoverImage = "https://i.pinimg.com/originals/17/aa/71/17aa718c1ab15b482505b8431cf596fc.jpg",
                Rating = 4.9,
                MediaType = MediaType.Movie
            };

            var m13 = new Media
            {
                Id = 13,
                Title = "Chernobyl",
                Description = "In April 1986, the city of Chernobyl in the Soviet Union suffers one of the worst nuclear disasters in the history of mankind. Consequently, many heroes put their lives on the line to save Europe.",
                ReleaseDate = new DateTime(2019, 4, 6),
                CoverImage = "https://i.pinimg.com/originals/06/b2/2f/06b22f1ec7b9a6914ec6255f40953e98.jpg",
                Rating = 3.6,
                MediaType = MediaType.TvShow
            };

            var m14 = new Media
            {
                Id = 14,
                Title = "La Casa De Papel",
                Description = "A criminal mastermind who goes by \"The Professor\" has a plan to pull off the biggest heist in recorded history -- to print billions of euros in the Royal Mint of Spain. To help him carry out the ambitious plan, he recruits eight people with certain abilities and who have nothing to lose.",
                ReleaseDate = new DateTime(2017, 4, 2),
                CoverImage = "https://www.enigma-mag.com/wp-content/uploads/2019/08/1563490297.jpg",
                Rating = 4,
                MediaType = MediaType.TvShow
            };

            var m15 = new Media
            {
                Id = 15,
                Title = "Modern Family",
                Description = "Three modern-day families from California try to deal with their kids, quirky spouses and jobs in their own unique ways, often falling into hilarious situations.",
                ReleaseDate = new DateTime(2009, 8, 23),
                CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/0/09/Modern_Family_Season_Two_DVD_Cover.png/250px-Modern_Family_Season_Two_DVD_Cover.png",
                Rating = 4.3,
                MediaType = MediaType.TvShow
            };

            var m16 = new Media
            {
                Id = 16,
                Title = "The Mandalorian",
                Description = "After the defeat of the Empire at the hands of Rebel forces, a lone bounty hunter operating in the Outer Rim, away from the dominion of the New Republic, goes on many surprising and risky adventures.",
                ReleaseDate = new DateTime(2019, 10, 12),
                CoverImage = "https://lumiere-a.akamaihd.net/v1/images/p_fyc_themandalorian_19097_de619ea9.jpeg",
                Rating = 4.2,
                MediaType = MediaType.TvShow
            };

            var m17 = new Media
            {
                Id = 17,
                Title = "Harry Potter and the Philosopher's Stone",
                Description = "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
                ReleaseDate = new DateTime(2001, 11, 14),
                CoverImage = "https://movieguise.files.wordpress.com/2016/01/potter.jpg",
                Rating = 4.6,
                MediaType = MediaType.Movie
            };

            var m18 = new Media
            {
                Id = 18,
                Title = "Harry Potter and The Chamber Of Secrets",
                Description = "A house-elf warns Harry against returning to Hogwarts, but he decides to ignore it. When students and creatures at the school begin to get petrified, Harry finds himself surrounded in mystery.",
                ReleaseDate = new DateTime(2002, 11, 3),
                CoverImage = "https://www.hylandcinema.com/files/hyland/movie-posters/hp-_chamber.jpg",
                Rating = 4.4,
                MediaType = MediaType.Movie
            };

            var m19 = new Media
            {
                Id = 19,
                Title = "Harry Potter and The Prisoner Of Azkaban",
                Description = "Harry, Ron and Hermoine return to Hogwarts just as they learn about Sirius Black and his plans to kill Harry. However, when Harry runs into him, he learns that the truth is far from reality.",
                ReleaseDate = new DateTime(2004, 5, 31),
                CoverImage = "https://static.wikia.nocookie.net/warner-bros-entertainment/images/c/cb/Harry-potter-and-the-prisoner-of-azkaban-movie-poster-style-f-11x17.jpg",
                Rating = 4,
                MediaType = MediaType.Movie
            };

            var m20 = new Media
            {
                Id = 20,
                Title = "Agents of S.H.I.E.L.D.",
                Description = "Agent Phil Coulson leads a team of highly skilled agents from the global law-enforcement organisation known as S.H.I.E.L.D. Together, they combat extraordinary and inexplicable threats.",
                ReleaseDate = new DateTime(2013, 9, 24),
                CoverImage = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/1/10/AoS_Season_One_Poster.jpg",
                Rating = 4.9,
                MediaType = MediaType.TvShow
            };

            var m21 = new Media
            {
                Id = 21,
                Title = "Years and Years",
                Description = "An ordinary British family contends with the hopes, anxieties and joys of an uncertain future in this six-part limited series that begins in 2019 and propels the characters 15 years forward into an unstable world.",
                ReleaseDate = new DateTime(2019, 5, 14),
                CoverImage = "https://i.pinimg.com/474x/4e/96/06/4e9606a7f386cafa7903e28e94e43627.jpg",
                Rating = 2.7,
                MediaType = MediaType.TvShow
            };

            var m22 = new Media
            {
                Id = 22,
                Title = "MacGyver",
                Description = "MacGyver, a contemporary hero and role model, applies his scientific knowledge to ordinary items to create a means of escape for himself and others from impending doom.",
                ReleaseDate = new DateTime(2016, 9, 23),
                CoverImage = "https://m.media-amazon.com/images/M/MV5BMTg1NzUzNmQtMWI2ZC00YzdlLWI5ZTgtMGM3MjJlZTgwYTVlXkEyXkFqcGdeQXVyMTIzMzY2NDQ2._V1_FMjpg_UX1000_.jpg",
                Rating = 3.3,
                MediaType = MediaType.TvShow
            };

            var m23 = new Media
            {
                Id = 23,
                Title = "Grey's Anatomy",
                Description = "Surgical interns and their supervisors embark on a medical journey where they become part of heart-wrenching stories and make life-changing decisions in order to become the finest doctors.",
                ReleaseDate = new DateTime(2005, 3, 27),
                CoverImage = "http://www.gstatic.com/tv/thumb/tvbanners/17114349/p17114349_b_v12_aa.jpg",
                Rating = 5,
                MediaType = MediaType.TvShow
            };

            var m24 = new Media
            {
                Id = 24,
                Title = "Euphoria",
                Description = "An American adaptation of the Israeli show of the same name, \"Euphoria\" follows the troubled life of 17-year-old Rue, a drug addict fresh from rehab with no plans to stay clean.",
                ReleaseDate = new DateTime(2019, 6, 16),
                CoverImage = "https://lanetechchampion.org/wp-content/uploads/2020/09/zendya-euphoria.jpg",
                Rating = 3,
                MediaType = MediaType.TvShow
            };

            var m25 = new Media
            {
                Id = 25,
                Title = "The Witcher",
                Description = "The witcher Geralt, a mutated monster hunter, struggles to find his place in a world in which people often prove more wicked than beasts.",
                ReleaseDate = new DateTime(2019, 12, 20),
                CoverImage = "https://www.syfy.com/sites/syfy/files/styles/1170xauto/public/the-witcher-season-2-poster-vertical.jpg",
                Rating = 5,
                MediaType = MediaType.TvShow
            };

            var m26 = new Media
            {
                Id = 26,
                Title = "Chilling Adventures of Sabrina",
                Description = "This adaptation of the \"Sabrina the Teenage Witch\" tale is a dark coming-of-age story that traffics in horror and the occult. In the reimagined origin story, Sabrina Spellman wrestles to reconcile her dual nature - half-witch, half-mortal.",
                ReleaseDate = new DateTime(2018, 10, 26),
                CoverImage = "https://images-na.ssl-images-amazon.com/images/I/81bLWVTR3sL.jpg",
                Rating = 4.1,
                MediaType = MediaType.TvShow
            };
            #endregion

            #region Ratings
            var r1 = new Rating { Id = 1, Value = 5, RatedMediaId = m1.Id };
            var r2 = new Rating { Id = 2, Value = 4.8, RatedMediaId = m2.Id };
            var r3 = new Rating { Id = 3, Value = 4.5, RatedMediaId = m3.Id };
            var r4 = new Rating { Id = 4, Value = 5, RatedMediaId = m4.Id };
            var r5 = new Rating { Id = 5, Value = 4.9, RatedMediaId = m5.Id };
            var r6 = new Rating { Id = 6, Value = 4.5, RatedMediaId = m6.Id };
            var r7 = new Rating { Id = 7, Value = 4.9, RatedMediaId = m7.Id };
            var r8 = new Rating { Id = 8, Value = 4, RatedMediaId = m8.Id };
            var r9 = new Rating { Id = 9, Value = 3.5, RatedMediaId = m9.Id };
            var r10 = new Rating { Id = 10, Value = 3.8, RatedMediaId = m10.Id };
            var r11 = new Rating { Id = 11, Value = 4.2, RatedMediaId = m11.Id };
            var r12 = new Rating { Id = 12, Value = 4.9, RatedMediaId = m12.Id };
            var r13 = new Rating { Id = 13, Value = 3.6, RatedMediaId = m13.Id };
            var r14 = new Rating { Id = 14, Value = 4, RatedMediaId = m14.Id };
            var r15 = new Rating { Id = 15, Value = 4.3, RatedMediaId = m15.Id };
            var r16 = new Rating { Id = 16, Value = 4.2, RatedMediaId = m16.Id };
            var r17 = new Rating { Id = 17, Value = 4.6, RatedMediaId = m17.Id };
            var r18 = new Rating { Id = 18, Value = 4.4, RatedMediaId = m18.Id };
            var r19 = new Rating { Id = 19, Value = 4, RatedMediaId = m19.Id };
            var r20 = new Rating { Id = 20, Value = 4.9, RatedMediaId = m20.Id };
            var r21 = new Rating { Id = 21, Value = 2.7, RatedMediaId = m21.Id };
            var r22 = new Rating { Id = 22, Value = 3.3, RatedMediaId = m22.Id };
            var r23 = new Rating { Id = 23, Value = 5, RatedMediaId = m23.Id };
            var r24 = new Rating { Id = 24, Value = 3, RatedMediaId = m24.Id };
            var r25 = new Rating { Id = 25, Value = 5, RatedMediaId = m25.Id };
            var r26 = new Rating { Id = 26, Value = 4.1, RatedMediaId = m26.Id };
            #endregion

            modelBuilder.Entity<CastMember>().HasData(
                cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8, cm9, cm10, cm11,
                cm12, cm13, cm14, cm15, cm16, cm17, cm18, cm19, cm20, cm21, cm22,
                cm23, cm24, cm25, cm26, cm27, cm28, cm29, cm30, cm31, cm32, cm33,
                cm34, cm35, cm36, cm37, cm38, cm39, cm40, cm41, cm42, cm43, cm44,
                cm45, cm46, cm47, cm48, cm49, cm50, cm51, cm52, cm53, cm54, cm55,
                cm56, cm57, cm58, cm59, cm60
            );

            modelBuilder.Entity<Media>().HasData(
                m1, m2, m3, m4, m5, m6, m7, m8, m9, m10,
                m11, m12, m13, m14, m15, m16, m17, m18, m19, m20,
                m21, m22, m23, m24, m25, m26
            );

            modelBuilder.Entity<Rating>().HasData(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26
            );
        }
    }
}