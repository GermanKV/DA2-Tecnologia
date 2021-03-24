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
                Category = new Category
                {
                    Id = 1,
                    Name = "Ciencia ficcion"
                },
                Description = "Autos que son aliens",
                Stars = 3,
                Director = new Director
                {
                    Id = 1,
                    Name = "John Rogers"
                }
            },
            new Movie
            {
                Id = 2,
                Title = "Transformers 2",
                ReleaseDate = new DateTime(2009,6,24),
                Category = new Category
                {
                    Id = 1,
                    Name = "Ciencia ficcion "
                },
                Description = "Autos que son aliens",
                Stars = 2,
                Director = new Director
                {
                    Id = 1,
                    Name = "John Rogers"
                }
            },
            new Movie
            {
                Id = 3,
                Title = "Transformers 3",
                ReleaseDate = new DateTime(2011,6,29),
                Category = new Category
                {
                    Id = 1,
                    Name = "Ciencia ficcion 2"
                },
                Description = "Autos que son aliens",
                Stars = 5,
                Director = new Director
                {
                    Id = 1,
                    Name = "John Rogers"
                }
            }
        };

        [HttpGet]
        public IActionResult GetAllMoviesFiltered([FromQuery] MovieQueryParam movieQueryParam)
        {
            IEnumerable<Movie> movies = this.movies.Where(movie => movie.Category.Name == movieQueryParam.Category && movie.ReleaseDate.Year == movieQueryParam.Year);

            return Ok(movies);
        }

        //GET movies/movieId
        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            Movie movie = this.movies.FirstOrDefault(movie => movie.Id == movieId);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            movie.Id = this.movies.Count + 1;

            this.movies.Add(movie);

            return CreatedAtRoute("GetMovieById", movie.Id, movie);
        }

        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId, Movie movie)
        {
            Movie movieToUpdate = this.movies.FirstOrDefault(movie => movie.Id == movieId);

            if(movie is null)
            {
                return BadRequest($"No existe una pelicula con el id {movieId}");
            }

            movieToUpdate = movie;
            movieToUpdate.Id = movieId;

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovieById(int movieId)
        {
            Movie movieToRemove = this.movies.FirstOrDefault(movie => movie.Id == movieId);

            if(movieToRemove is null)
            {
                return BadRequest($"No existe una pelicula con el id {movieId}");
            }

            this.movies.Remove(movieToRemove);

            return NoContent();
        }
    }
}
