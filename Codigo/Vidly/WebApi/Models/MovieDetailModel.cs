using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Models
{
    public class MovieDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; } //Title
        public string ReleaseDate { get; set; }
        public string Director { get; set; } //Director
        public int Rank { get; set; } //Stars
        public string Category { get; set; }//Category
    }
}
