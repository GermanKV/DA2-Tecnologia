using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbContext context;
        private readonly DbSet<Movie> movies;

        public MovieRepository(DbContext context)
        {
            this.context = context;
            this.movies = context.Set<Movie>();
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.movies;
        }

        public Movie Add(Movie movie)
        {
            this.movies.Add(movie);
            this.context.SaveChanges();

            return movie;
        }
    }
}
