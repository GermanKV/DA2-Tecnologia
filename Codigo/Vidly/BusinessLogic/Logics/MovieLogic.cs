using BusinessLogicInterface;
using DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieRepository moviesRepository;

        public MovieLogic(IMovieRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }
    }
}
