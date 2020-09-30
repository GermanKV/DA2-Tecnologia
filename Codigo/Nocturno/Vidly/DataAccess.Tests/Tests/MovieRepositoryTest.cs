using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private DbContext context;
        private DbContextOptions options;

        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void TestGetAllMoviesOk()
        {
            List<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Iron man 3",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Iron man 2",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    Duration = 1.5
                }
            };

            moviesToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            var repository = new MovieRepository(context);

            var result = repository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetMovieOk()
        {
            var movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            this.context.Add(movie);
            this.context.SaveChanges();
            var repository = new MovieRepository(context);

            var result = repository.Get(1);

            Assert.AreEqual(movie, result);
        }

        [TestMethod]
        public void TestAddMovieOk()
        {
            Movie movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            var repository = new MovieRepository(this.context);

            var result = repository.Add(movie);
            
            Assert.AreEqual(repository.GetAll().Count(), 1);
        }

        [TestMethod]
        public void TestUpdateMovieOk()
        {
            Movie movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            this.context.Add(movie);
            this.context.SaveChanges();
            movie.Name = "Elona Holmes 2";
            var repository = new MovieRepository(this.context);

            repository.Update(movie);

            Assert.AreEqual(repository.Get(1), movie);
        }

        [TestMethod]
        public void TestDeleteMovieOk()
        {
            Movie movie = new Movie()
            {
                Name = "Elona Holmes",
                AgeAllowed = 12,
                CategoryId = 1,
                Description = "La herama de Sherlock y Mycroft Holmes",
                Duration = 2.1,
                Image = "Mi directorio",
            };
            this.context.Add(movie);
            this.context.SaveChanges();
            var repository = new MovieRepository(this.context);
            var movieToDelete = repository.Get(1);

            repository.Delete(movieToDelete);

            Assert.AreEqual(repository.GetAll().Count(), 0);
        }
    }
}