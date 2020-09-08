using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        //api/movies?name=Transformers&gender=5&ageAllowed=13
        //Traer todas las peliculas
        [HttpGet]
        public void Get([FromQuery] object query)
        {

        }

        //api/movies/5
        //Traer una pelicula en especifico
        [HttpGet("{id}")]
        public void Get([FromRoute] int id)
        {

        }

        //api/movies
        [HttpPost]
        public void Post([FromBody] object movie)
        {

        }

        //api/movies/5
        [HttpPut("{id}")]
        public void Put([FromRoute] int id, [FromBody] object movie)
        {

        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {

        }
    }
}