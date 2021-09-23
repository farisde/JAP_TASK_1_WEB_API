using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MovieBuff.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastMemberMedia",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    StarredMediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMemberMedia", x => new { x.CastId, x.StarredMediaId });
                    table.ForeignKey(
                        name: "FK_CastMemberMedia_CastMembers_CastId",
                        column: x => x.CastId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastMemberMedia_Medias_StarredMediaId",
                        column: x => x.StarredMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    RatedMediaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Medias_RatedMediaId",
                        column: x => x.RatedMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CastMembers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Carrie Fisher" },
                    { 33, "Carl Weathers" },
                    { 34, "Daniel Radcliffe" },
                    { 35, "Emma Watson" },
                    { 36, "Rupert Grint" },
                    { 37, "Chloe Bennet" },
                    { 38, "Elizabeth Henstridge" },
                    { 39, "Ming‑Na Wen" },
                    { 40, "Emma Thompson" },
                    { 41, "Russell Tovey" },
                    { 42, "Ruth Madeley" },
                    { 44, "Tristin Mays" },
                    { 45, "Meredith Eaton" },
                    { 46, "Ellen Pompeo" },
                    { 47, "Chandra Wilson" },
                    { 48, "James Pickens Jr." },
                    { 49, "Zendaya" },
                    { 50, "Hunter Schafer" },
                    { 51, "Jacob Elordi" },
                    { 52, "Henry Cavil" },
                    { 53, "Anya Chalotra" },
                    { 54, "Freya Allan" },
                    { 55, "Kiernan Shipka" },
                    { 56, "Ross Lynch" },
                    { 57, "Gavin Leatherwood" },
                    { 58, "Zoe Saldana" },
                    { 59, "Sam Worthington" },
                    { 60, "Sigourney Weaver" },
                    { 32, "Giancarlo Esposito" },
                    { 31, "Gina Carano" },
                    { 43, "Lucas Till" },
                    { 29, "Sarah Hyland" },
                    { 2, "Mark Hamil" },
                    { 30, "Pedro Pascal" },
                    { 4, "Cole Sprouse" },
                    { 5, "Lili Reinhart" },
                    { 6, "Camila Mendes" },
                    { 7, "KJ Apa" },
                    { 8, "James Spader" },
                    { 9, "Megan Boone" },
                    { 10, "Diego Klattenhoff" },
                    { 11, "Henry Lennix" }
                });

            migrationBuilder.InsertData(
                table: "CastMembers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Daisy Ridley" },
                    { 13, "Adam Driver" },
                    { 14, "Natalie Portman" },
                    { 15, "Ewan McGregor" },
                    { 3, "Harrison Ford" },
                    { 17, "Hayden Christensen" },
                    { 16, "Liam Neeson" },
                    { 27, "Eric Stonestreet" },
                    { 26, "Sofía Vergara" },
                    { 25, "Miguel Herrán" },
                    { 24, "Itziar Ituño" },
                    { 23, "Álvaro Morte" },
                    { 28, "Julie Bowen" },
                    { 21, "Paul Ritter" },
                    { 20, "Emily Watson" },
                    { 19, "Stellan Skarsgård" },
                    { 18, "Jared Harris" },
                    { 22, "Úrsula Corberó" }
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "CoverImage", "Description", "MediaType", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 15, "https://upload.wikimedia.org/wikipedia/en/thumb/0/09/Modern_Family_Season_Two_DVD_Cover.png/250px-Modern_Family_Season_Two_DVD_Cover.png", "Three modern-day families from California try to deal with their kids, quirky spouses and jobs in their own unique ways, often falling into hilarious situations.", 2, 4.2999999999999998, new DateTime(2009, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modern Family" },
                    { 16, "https://lumiere-a.akamaihd.net/v1/images/p_fyc_themandalorian_19097_de619ea9.jpeg", "After the defeat of the Empire at the hands of Rebel forces, a lone bounty hunter operating in the Outer Rim, away from the dominion of the New Republic, goes on many surprising and risky adventures.", 2, 4.2000000000000002, new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Mandalorian" },
                    { 17, "https://movieguise.files.wordpress.com/2016/01/potter.jpg", "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.", 1, 4.5999999999999996, new DateTime(2001, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { 18, "https://www.hylandcinema.com/files/hyland/movie-posters/hp-_chamber.jpg", "A house-elf warns Harry against returning to Hogwarts, but he decides to ignore it. When students and creatures at the school begin to get petrified, Harry finds himself surrounded in mystery.", 1, 4.4000000000000004, new DateTime(2002, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and The Chamber Of Secrets" },
                    { 20, "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/1/10/AoS_Season_One_Poster.jpg", "Agent Phil Coulson leads a team of highly skilled agents from the global law-enforcement organisation known as S.H.I.E.L.D. Together, they combat extraordinary and inexplicable threats.", 2, 4.9000000000000004, new DateTime(2013, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agents of S.H.I.E.L.D." },
                    { 21, "https://i.pinimg.com/474x/4e/96/06/4e9606a7f386cafa7903e28e94e43627.jpg", "An ordinary British family contends with the hopes, anxieties and joys of an uncertain future in this six-part limited series that begins in 2019 and propels the characters 15 years forward into an unstable world.", 2, 2.7000000000000002, new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Years and Years" },
                    { 22, "https://m.media-amazon.com/images/M/MV5BMTg1NzUzNmQtMWI2ZC00YzdlLWI5ZTgtMGM3MjJlZTgwYTVlXkEyXkFqcGdeQXVyMTIzMzY2NDQ2._V1_FMjpg_UX1000_.jpg", "MacGyver, a contemporary hero and role model, applies his scientific knowledge to ordinary items to create a means of escape for himself and others from impending doom.", 2, 3.2999999999999998, new DateTime(2016, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "MacGyver" },
                    { 23, "http://www.gstatic.com/tv/thumb/tvbanners/17114349/p17114349_b_v12_aa.jpg", "Surgical interns and their supervisors embark on a medical journey where they become part of heart-wrenching stories and make life-changing decisions in order to become the finest doctors.", 2, 5.0, new DateTime(2005, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grey's Anatomy" },
                    { 14, "https://www.enigma-mag.com/wp-content/uploads/2019/08/1563490297.jpg", "A criminal mastermind who goes by \"The Professor\" has a plan to pull off the biggest heist in recorded history -- to print billions of euros in the Royal Mint of Spain. To help him carry out the ambitious plan, he recruits eight people with certain abilities and who have nothing to lose.", 2, 4.0, new DateTime(2017, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "La Casa De Papel" },
                    { 24, "https://lanetechchampion.org/wp-content/uploads/2020/09/zendya-euphoria.jpg", "An American adaptation of the Israeli show of the same name, \"Euphoria\" follows the troubled life of 17-year-old Rue, a drug addict fresh from rehab with no plans to stay clean.", 2, 3.0, new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euphoria" },
                    { 19, "https://static.wikia.nocookie.net/warner-bros-entertainment/images/c/cb/Harry-potter-and-the-prisoner-of-azkaban-movie-poster-style-f-11x17.jpg", "Harry, Ron and Hermoine return to Hogwarts just as they learn about Sirius Black and his plans to kill Harry. However, when Harry runs into him, he learns that the truth is far from reality.", 1, 4.0, new DateTime(2004, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and The Prisoner Of Azkaban" },
                    { 13, "https://i.pinimg.com/originals/06/b2/2f/06b22f1ec7b9a6914ec6255f40953e98.jpg", "In April 1986, the city of Chernobyl in the Soviet Union suffers one of the worst nuclear disasters in the history of mankind. Consequently, many heroes put their lives on the line to save Europe.", 2, 3.6000000000000001, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chernobyl" },
                    { 7, "https://i.pinimg.com/originals/f4/5a/ea/f45aea75f65c0feb5cbe168f17a9a087.jpg", "Rey seeks to learn the ways of the Jedi under Luke Skywalker, its remaining member, to reinvigorate the Resistance's war against the First Order.", 1, 4.9000000000000004, new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Last Jedi (Episode VIII)" },
                    { 11, "https://play-lh.googleusercontent.com/mMyoXM8bf72KK-Udap4-hAvqqdXgn0AIBXkS8zejT0RXITIh8oK9a-SYIVk89CA0rHJi", "Anakin joins forces with Obi-Wan and sets Palpatine free from the evil clutches of Count Doku. However, he falls prey to Palpatine and the Jedis' mind games and gives into temptation.", 1, 4.2000000000000002, new DateTime(2005, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Revenge of the Sith (Episode III)" },
                    { 10, "https://m.media-amazon.com/images/M/MV5BMDAzM2M0Y2UtZjRmZi00MzVlLTg4MjEtOTE3NzU5ZDVlMTU5XkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_.jpg", "While pursuing an assassin, Obi Wan uncovers a sinister plot to destroy the Republic. With the fate of the galaxy hanging in the balance, the Jedi must defend the galaxy against the evil Sith.", 1, 3.7999999999999998, new DateTime(2002, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Attack of the Clones (Episode II)" },
                    { 9, "https://play-lh.googleusercontent.com/sR1pzOxnF50WLR3vUqXYFvY01_tLD4XPn1RDHf0Xh-W04Vek_3iiZ98U7Db2JcmrqS8", "Jedi Knights Qui-Gon Jinn and Obi-Wan Kenobi set out to stop the Trade Federation from invading Naboo. While travelling, they come across a gifted boy, Anakin, and learn that the Sith have returned.", 1, 3.5, new DateTime(1999, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Phantom Menace (Episode I)" },
                    { 8, "https://lumiere-a.akamaihd.net/v1/images/star-wars-the-rise-of-skywalker-theatrical-poster-1000_ebc74357.jpeg?region=0%2C0%2C891%2C1372", "The revival of Emperor Palpatine resurrects the battle between the Resistance and the First Order while the Jedi's legendary conflict with the Sith Lord comes to a head.", 1, 4.0, new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Rise of Skywalker (Episode IX)" },
                    { 6, "https://m.media-amazon.com/images/M/MV5BOTAzODEzNDAzMl5BMl5BanBnXkFtZTgwMDU1MTgzNzE@._V1_.jpg", "A new order threatens to destroy the New Republic. Finn, Rey and Poe, backed by the Resistance and the Republic, must find a way to stop them and find Luke, the last surviving Jedi.", 1, 4.5, new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Force Awakens (Episode VII)" },
                    { 5, "https://m.media-amazon.com/images/I/91LlN7J+Z9L._SL1500_.jpg", "Luke Skywalker attempts to bring his father back to the light side of the Force. At the same time, the rebels hatch a plan to destroy the second Death Star.", 1, 4.9000000000000004, new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Return of the Jedi (Episode VI)" },
                    { 4, "https://static.wikia.nocookie.net/blacklist/images/5/57/Season_7_Poster.jpg", "A wanted fugitive mysteriously surrenders himself to the FBI and offers to help them capture deadly criminals. His sole condition is that he will work only with the new profiler, Elizabeth Keen.", 2, 5.0, new DateTime(2013, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Blacklist" },
                    { 3, "https://static.wikia.nocookie.net/riverdalearchie/images/3/3a/Season_2_Poster.jpg", "Archie, Betty, Jughead and Veronica tackle being teenagers in a town that is rife with sinister happenings and blood-thirsty criminals.", 2, 4.5, new DateTime(2017, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riverdale" },
                    { 2, "https://images.penguinrandomhouse.com/cover/9780345320223", "Darth Vader is adamant about turning Luke Skywalker to the dark side. Master Yoda trains Luke to become a Jedi Knight while his friends try to fend off the Imperial fleet.", 1, 4.7999999999999998, new DateTime(1980, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Empire Strikes Back (Episode V)" },
                    { 1, "https://kbimages1-a.akamaihd.net/538b1473-6d45-47f4-b16e-32a0a6ba7f9a/1200/1200/False/star-wars-episode-iv-a-new-hope-3.jpg", "After Princess Leia, the leader of the Rebel Alliance, is held hostage by Darth Vader, Luke and Han Solo must free her and destroy the powerful weapon created by the Galactic Empire.", 1, 5.0, new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: A New Hope (Episode IV)" },
                    { 25, "https://www.syfy.com/sites/syfy/files/styles/1170xauto/public/the-witcher-season-2-poster-vertical.jpg", "The witcher Geralt, a mutated monster hunter, struggles to find his place in a world in which people often prove more wicked than beasts.", 2, 5.0, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher" }
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "CoverImage", "Description", "MediaType", "Rating", "ReleaseDate", "Title" },
                values: new object[] { 12, "https://i.pinimg.com/originals/17/aa/71/17aa718c1ab15b482505b8431cf596fc.jpg", "Jake, who is paraplegic, replaces his twin on the Na'vi inhabited Pandora for a corporate mission. After the natives accept him as one of their own, he must decide where his loyalties lie.", 1, 4.9000000000000004, new DateTime(2009, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar" });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "CoverImage", "Description", "MediaType", "Rating", "ReleaseDate", "Title" },
                values: new object[] { 26, "https://images-na.ssl-images-amazon.com/images/I/81bLWVTR3sL.jpg", "This adaptation of the \"Sabrina the Teenage Witch\" tale is a dark coming-of-age story that traffics in horror and the occult. In the reimagined origin story, Sabrina Spellman wrestles to reconcile her dual nature - half-witch, half-mortal.", 2, 4.0999999999999996, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilling Adventures of Sabrina" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "RatedMediaId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, null, 5.0 },
                    { 24, 24, null, 3.0 },
                    { 23, 23, null, 5.0 },
                    { 22, 22, null, 3.2999999999999998 },
                    { 21, 21, null, 2.7000000000000002 },
                    { 20, 20, null, 4.9000000000000004 },
                    { 19, 19, null, 4.0 },
                    { 18, 18, null, 4.4000000000000004 },
                    { 17, 17, null, 4.5999999999999996 },
                    { 16, 16, null, 4.2000000000000002 },
                    { 15, 15, null, 4.2999999999999998 },
                    { 14, 14, null, 4.0 },
                    { 13, 13, null, 3.6000000000000001 },
                    { 12, 12, null, 4.9000000000000004 },
                    { 11, 11, null, 4.2000000000000002 },
                    { 10, 10, null, 3.7999999999999998 },
                    { 9, 9, null, 3.5 },
                    { 8, 8, null, 4.0 },
                    { 7, 7, null, 4.9000000000000004 },
                    { 6, 6, null, 4.5 },
                    { 5, 5, null, 4.9000000000000004 },
                    { 4, 4, null, 5.0 },
                    { 3, 3, null, 4.5 },
                    { 2, 2, null, 4.7999999999999998 },
                    { 25, 25, null, 5.0 },
                    { 26, 26, null, 4.0999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "CastMemberMedia",
                columns: new[] { "CastId", "StarredMediaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 4 },
                    { 9, 4 },
                    { 10, 4 },
                    { 11, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 12, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 12, 7 },
                    { 1, 8 },
                    { 12, 8 },
                    { 13, 8 },
                    { 14, 9 },
                    { 15, 9 },
                    { 16, 9 },
                    { 17, 10 },
                    { 14, 10 },
                    { 15, 10 },
                    { 17, 11 },
                    { 14, 11 },
                    { 15, 11 },
                    { 58, 12 },
                    { 59, 12 },
                    { 60, 12 },
                    { 18, 13 },
                    { 19, 13 },
                    { 20, 13 },
                    { 21, 13 },
                    { 22, 14 },
                    { 23, 14 },
                    { 24, 14 },
                    { 25, 14 },
                    { 26, 15 },
                    { 27, 15 },
                    { 28, 15 },
                    { 29, 15 },
                    { 30, 16 },
                    { 31, 16 },
                    { 32, 16 },
                    { 33, 16 },
                    { 34, 17 },
                    { 35, 17 },
                    { 36, 17 },
                    { 34, 18 },
                    { 35, 18 },
                    { 36, 18 },
                    { 34, 19 },
                    { 35, 19 },
                    { 36, 19 },
                    { 37, 20 },
                    { 38, 20 },
                    { 39, 20 },
                    { 40, 21 },
                    { 41, 21 },
                    { 42, 21 },
                    { 43, 22 },
                    { 44, 22 },
                    { 45, 22 },
                    { 46, 23 },
                    { 47, 23 },
                    { 48, 23 },
                    { 49, 24 },
                    { 50, 24 },
                    { 51, 24 },
                    { 52, 25 },
                    { 53, 25 },
                    { 54, 25 },
                    { 55, 26 },
                    { 56, 26 },
                    { 57, 26 },
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastMemberMedia_StarredMediaId",
                table: "CastMemberMedia",
                column: "StarredMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedMediaId",
                table: "Ratings",
                column: "RatedMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastMemberMedia");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "CastMembers");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
