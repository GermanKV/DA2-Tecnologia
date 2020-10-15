using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
        public int AgeAllowed { get; set; }
        public double Duration { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if(obj is Movie movie)
            {
                result = this.Id == movie.Id && this.Name.Equals(movie.Name);
            }

            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = 1328192014;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + AgeAllowed.GetHashCode();
            hashCode = hashCode * -1521134295 + Duration.GetHashCode();
            hashCode = hashCode * -1521134295 + CategoryId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Category>.Default.GetHashCode(Category);
            return hashCode;
        }
    }
}
