using System;
using System.Collections.Generic;
using Movie.Core.Models;

namespace DAL.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(MovieCreator mov);
        void EditMovie(MovieCreator mov);
        void DeleteMovie(Movie.Core.Models.Movie mov);
        void DeleteByIdMovie(Guid id);
        void DeleteByTitleMovie(string title);
        MovieCreator GetMovie(string tit);
        List<MovieCreator> GetAllMovies();
        List<MovieCreator> Querry(string param, string val);
        List<MovieCreator> Querry(string param);
    }
}
