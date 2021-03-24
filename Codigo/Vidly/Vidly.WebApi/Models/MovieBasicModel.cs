using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Models
{
    public class MovieBasicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Year { get; set; }
    }
}
