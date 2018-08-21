using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMovieRepository
    {
        void AddMovie(MovieCreator mov);
        void EditMovie(Movie mov);
        void DeleteMovie(Movie mov);
        void DeleteByIdMovie(Guid id);
        void DeleteByTitleMovie(string title);
        MovieCreator GetMovie(string tit);
        List<MovieCreator> GetAllMovies();
        List<MovieCreator> Querry(string param, string val);
        List<MovieCreator> Querry(string param);
    }
}
