using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Domain
{
    // Id | Title | Description | Stars | DirectorId | ReleaseDate | CategoryId
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate{ get; set; }
        public int Stars { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
