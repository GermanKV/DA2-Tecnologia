using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Models
{
    public class MovieDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Director { get; set; }
        public int Rank { get; set; }
    }
}
