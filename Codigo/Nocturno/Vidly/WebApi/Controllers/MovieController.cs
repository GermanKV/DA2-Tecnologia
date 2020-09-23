
using System.Linq;
using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    [ServiceFilter(typeof(AuthorizationDIFilter))]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic moviesLogic;

        public MovieController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }
        
        //api/movies
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.moviesLogic.GetAll().Select(m => new MovieBasicInfoModel(m)));
        }

        //api/movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get([FromRoute]int id)
        {
            return Ok();
        }

        //api/movies?ageAllowed=5
        /*[HttpGet]
        public IActionResult GetBy([FromQuery]int ageAllowed)
        {
            return Ok();
        }*/

        //api/movies
        [HttpPost]
        public IActionResult Post([FromBody]MovieModel movie)
        {
            return Ok();
        }

        //api/movies/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]MovieModel movie)
        {
            return Ok();
        }

        //api/movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            return Ok();
        }

        //api/movies
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        public class MovieModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Duration { get; set; }
        }
    }
}