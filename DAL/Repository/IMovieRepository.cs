﻿using System;
using System.Collections.Generic;
using Movie.Core.Models;

namespace DAL.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(MovieCreator mov);
        void EditMovie(MovieCreator mov);
        void DeleteByTitleMovie(string title);
        MovieCreator GetMovie(string tit);
        List<MovieCreator> GetAllMovies();
        
    }
}
