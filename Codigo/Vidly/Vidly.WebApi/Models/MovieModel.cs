using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Models
{
    public class MovieModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
    }
}
