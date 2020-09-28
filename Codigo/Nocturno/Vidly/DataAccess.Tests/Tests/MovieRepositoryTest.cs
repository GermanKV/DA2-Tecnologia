using System.Collections.Generic;
using System.Linq;
using DataAccess.Tests.Utils;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests
{
    [TestClass]
    public class MovieRepositoryTest
    {
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
            
            var options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDb").Options;
            var context = new VidlyContext(options);
            moviesToReturn.ForEach(m => context.Add(m));
            context.SaveChanges();
            var repository = new MovieRepository(context);

            var result = repository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetAllMoviesMockOk()
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
            var mockSet = new Mock<DbSet<Movie>>();
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(moviesToReturn.AsQueryable().GetEnumerator());
            var mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
            mockDbContext.Setup(d => d.Set<Movie>()).Returns(mockSet.Object);
            var repository = new MovieRepository(mockDbContext.Object);

            var result = repository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestAddMovieMockOk()
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
            var mockSet = new Mock<DbSet<Movie>>();
            mockSet.Setup(m => m.Add(It.IsAny<Movie>()));
            var mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
            mockDbContext.Setup(d => d.Set<Movie>()).Returns(mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(1);
            var repository = new MovieRepository(mockDbContext.Object);

            var result = repository.Add(movie);

            mockSet.VerifyAll();
            mockDbContext.VerifyAll();
            Assert.AreEqual(result, movie);
        }
    }
}