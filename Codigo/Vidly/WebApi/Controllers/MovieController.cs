using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.WebApi.Domain;
using Vidly.WebApi.QueryParams;

namespace Vidly.WebApi.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IList<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Transformers 1",
                ReleaseDate = new DateTime(2007,7,3),
                CategoryId = 1,
                Description = "Autos que son aliens",
                Stars = 3,
                DirectorId = 1
            },
            new Movie
            {
                Id = 2,
                Title = "Transformers 2",
                ReleaseDate = new DateTime(2009,6,24),
                CategoryId = 1,
                Description = "Autos que son aliens",
                Stars = 2,
                DirectorId = 1
            },
            new Movie
            {
                Id = 3,
                Title = "Transformers 3",
                ReleaseDate = new DateTime(2011,6,29),
                CategoryId = 2,
                Description = "Autos que son aliens",
                Stars = 5,
                DirectorId = 1
            }
        };

        //GET movies
        //StatusCode: 200, 400, 500
        [HttpGet]
        public IActionResult GetAllMoviesFiltered([FromQuery] MovieQueryParam movieQueryParam)
        {
            IEnumerable<Movie> movies = this.movies
                .Where(movie =>
                movie.Category.Name == movieQueryParam.Category
                && movie.ReleaseDate.Year == movieQueryParam.Year);

            return Ok(movies);
        }

        //GET movies/{movieId}
        //StatusCode: 200, 400, 500
        [HttpGet("{movieId}", Name = "GetMovieByIdUri")]
        public IActionResult GetMovieById(int movieId)
        {
            Movie movie = this.movies.FirstOrDefault(movie => movie.Id == movieId);

            if(movie is null)
            {
                return BadRequest($"No existe una pelicula con el id {movieId}");
            }

            return Ok(movie);
        }

        /*
         POST movies
         BODY: {
            'id': int,
            'title': string,
            'stars': int,
            'description': string,
            'releaseDate': DateTime,
            'directorId': int,
            'categoryId': int
         }
         */
        //StatusCode: 201, 400, 500
        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            movie.Id = this.movies.Count + 1;

            this.movies.Add(movie);

            return CreatedAtRoute("GetMovieByIdUri", movie.Id, movie);
        }

        /*
         PUT movies/{moviesId}
         BODY: {
            'id': int,
            'title': string,
            'stars': int,
            'description': string,
            'releaseDate': DateTime,
            'directorId': int,
            'categoryId': int
         }
         */
        //StatusCode: 204, 400, 500
        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId, Movie movie)
        {
            Movie movieToUpdate = this.movies.FirstOrDefault(movie => movie.Id == movieId);

            if (movieToUpdate is null)
            {
                return BadRequest($"No existe una pelicula con el id {movieId}");
            }

            movieToUpdate = movie;
            movieToUpdate.Id = movieId;

            return NoContent();
        }

        //DELETE movies/{movieId}
        //StatusCode: 204, 400, 500
        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovieById(int movieId)
        {
            Movie movieToRemove = this.movies.FirstOrDefault(movie => movie.Id == movieId);

            if (movieToRemove is null)
            {
                return BadRequest($"No existe una pelicula con el id {movieId}");
            }

            this.movies.Remove(movieToRemove);

            return NoContent();
        }
    }
}
