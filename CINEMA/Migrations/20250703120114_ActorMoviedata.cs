﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CINEMA.Migrations
{
    /// <inheritdoc />
    public partial class ActorMoviedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.Sql(" insert into ActorMovies (ActorsId, MoviesId) values (25, 10); insert into ActorMovies (ActorsId, MoviesId) values (29, 26); insert into ActorMovies (ActorsId, MoviesId) values (41, 21); insert into ActorMovies (ActorsId, MoviesId) values (23, 30); insert into ActorMovies (ActorsId, MoviesId) values (26, 11); insert into ActorMovies (ActorsId, MoviesId) values (2, 13); insert into ActorMovies (ActorsId, MoviesId) values (28, 15); insert into ActorMovies (ActorsId, MoviesId) values (43, 13); insert into ActorMovies (ActorsId, MoviesId) values (40, 11); insert into ActorMovies (ActorsId, MoviesId) values (49, 29); insert into ActorMovies (ActorsId, MoviesId) values (11, 24); insert into ActorMovies (ActorsId, MoviesId) values (13, 1); insert into ActorMovies (ActorsId, MoviesId) values (44, 19); insert into ActorMovies (ActorsId, MoviesId) values (10, 9); insert into ActorMovies (ActorsId, MoviesId) values (42, 14); insert into ActorMovies (ActorsId, MoviesId) values (5, 16); insert into ActorMovies (ActorsId, MoviesId) values (44, 7); insert into ActorMovies (ActorsId, MoviesId) values (46, 11); insert into ActorMovies (ActorsId, MoviesId) values (16, 12); insert into ActorMovies (ActorsId, MoviesId) values (34, 7); insert into ActorMovies (ActorsId, MoviesId) values (1, 22); insert into ActorMovies (ActorsId, MoviesId) values (9, 2); insert into ActorMovies (ActorsId, MoviesId) values (42, 8); insert into ActorMovies (ActorsId, MoviesId) values (38, 19); insert into ActorMovies (ActorsId, MoviesId) values (27, 21); insert into ActorMovies (ActorsId, MoviesId) values (14, 15); insert into ActorMovies (ActorsId, MoviesId) values (22, 25); insert into ActorMovies (ActorsId, MoviesId) values (5, 6); insert into ActorMovies (ActorsId, MoviesId) values (24, 9); insert into ActorMovies (ActorsId, MoviesId) values (22, 28); insert into ActorMovies (ActorsId, MoviesId) values (29, 13); insert into ActorMovies (ActorsId, MoviesId) values (2, 21); insert into ActorMovies (ActorsId, MoviesId) values (22, 22); insert into ActorMovies (ActorsId, MoviesId) values (18, 29); insert into ActorMovies (ActorsId, MoviesId) values (6, 2); insert into ActorMovies (ActorsId, MoviesId) values (42, 28); insert into ActorMovies (ActorsId, MoviesId) values (47, 9); insert into ActorMovies (ActorsId, MoviesId) values (6, 9); insert into ActorMovies (ActorsId, MoviesId) values (9, 23); insert into ActorMovies (ActorsId, MoviesId) values (47, 29); insert into ActorMovies (ActorsId, MoviesId) values (40, 23); insert into ActorMovies (ActorsId, MoviesId) values (39, 11); insert into ActorMovies (ActorsId, MoviesId) values (34, 15); insert into ActorMovies (ActorsId, MoviesId) values (37, 4); insert into ActorMovies (ActorsId, MoviesId) values (22, 21); insert into ActorMovies (ActorsId, MoviesId) values (30, 1); insert into ActorMovies (ActorsId, MoviesId) values (49, 24); insert into ActorMovies (ActorsId, MoviesId) values (10, 18); insert into ActorMovies (ActorsId, MoviesId) values (18, 19); insert into ActorMovies (ActorsId, MoviesId) values (30, 1); ");



        }



        /// <inheritdoc />

        protected override void Down(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.Sql("TRUNCATE TABLE ActorMovies");



        }
    }
}
