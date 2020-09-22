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
            var mockSet = new VidlyDbSet<Movie>();
            var mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
            mockDbContext.Setup(d => d.Set<Movie>()).Returns(mockSet.GetMockDbSet(moviesToReturn).Object);
            var repository = new MovieRepository(mockDbContext.Object);

            var result = repository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }
    }
}