using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.WebApi.Models;
using Vidly.WebApi.QueryParams;

namespace Vidly.WebApi.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic moviesLogic;

        public MovieController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }

        [HttpGet]
        public IActionResult GetAllMoviesFiltered([FromQuery] MovieQueryParam movieQueryParam)
        {
            IEnumerable<MovieBasicModel> movies = this.moviesLogic.GetAllFiltered(movieQueryParam);

            return Ok(movies);
        }

        //GET movies/movieId
        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            MovieDetailModel movie = this.moviesLogic.GetById(movieId);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieModel movie)
        {
            MovieDetailModel movieSaved = this.moviesLogic.Save(movie);

            return CreatedAtRoute("GetMovieById", movieSaved.Id, movieSaved);
        }

        [HttpPut("{movieId}")]
        public IActionResult Update(int movieId, MovieModel movie)
        {
            this.moviesLogic.Update(movieId, movie);

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        public IActionResult DeleteById(int movieId)
        {
            this.moviesLogic.Delete(movieId);
            return NoContent();
        }
    }
}
