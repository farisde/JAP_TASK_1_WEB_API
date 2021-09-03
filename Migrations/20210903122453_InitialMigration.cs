using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JAP_TASK_1_WEB_API.Migrations
{
    public partial class InitialMigration : Migration
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
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    IsMovie = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastMemberMovie",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    StarredMoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMemberMovie", x => new { x.CastId, x.StarredMoviesId });
                    table.ForeignKey(
                        name: "FK_CastMemberMovie_CastMembers_CastId",
                        column: x => x.CastId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastMemberMovie_Movies_StarredMoviesId",
                        column: x => x.StarredMoviesId,
                        principalTable: "Movies",
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
                    RatedMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_RatedMovieId",
                        column: x => x.RatedMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CastMembers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Carrie Fisher" },
                    { 2, "Mark Hamil" },
                    { 3, "Harrison Ford" },
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
                table: "Movies",
                columns: new[] { "Id", "CoverImage", "Description", "IsMovie", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "https://kbimages1-a.akamaihd.net/538b1473-6d45-47f4-b16e-32a0a6ba7f9a/1200/1200/False/star-wars-episode-iv-a-new-hope-3.jpg", "After Princess Leia, the leader of the Rebel Alliance, is held hostage by Darth Vader, Luke and Han Solo must free her and destroy the powerful weapon created by the Galactic Empire.", true, 5.0, new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: A New Hope (Episode IV)" },
                    { 2, "https://images.penguinrandomhouse.com/cover/9780345320223", "Darth Vader is adamant about turning Luke Skywalker to the dark side. Master Yoda trains Luke to become a Jedi Knight while his friends try to fend off the Imperial fleet.", true, 4.7999999999999998, new DateTime(1980, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Empire Strikes Back (Episode V)" },
                    { 3, "https://static.wikia.nocookie.net/riverdalearchie/images/3/3a/Season_2_Poster.jpg", "Archie, Betty, Jughead and Veronica tackle being teenagers in a town that is rife with sinister happenings and blood-thirsty criminals.", false, 4.5, new DateTime(2017, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riverdale" },
                    { 4, "https://static.wikia.nocookie.net/blacklist/images/5/57/Season_7_Poster.jpg", "A wanted fugitive mysteriously surrenders himself to the FBI and offers to help them capture deadly criminals. His sole condition is that he will work only with the new profiler, Elizabeth Keen.", false, 5.0, new DateTime(2013, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Blacklist" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "RatedMovieId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 5.0 },
                    { 2, 2, 4.7999999999999998 },
                    { 3, 3, 4.5 },
                    { 4, 4, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "CastMemberMovie",
                columns: new[] { "CastId", "StarredMoviesId" },
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
                    { 11, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastMemberMovie_StarredMoviesId",
                table: "CastMemberMovie",
                column: "StarredMoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedMovieId",
                table: "Ratings",
                column: "RatedMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastMemberMovie");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "CastMembers");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
