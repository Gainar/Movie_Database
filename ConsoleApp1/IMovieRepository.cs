using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMovieRepository
    {
        void AddMovie(Movie mov);
        void EditMovie(Movie mov);
        void DeleteMovie(Movie mov);
        void DeleteByIdMovie(Guid id);
        void DeleteByTitleMovie(string title);
        Movie GetMovie(Guid id);
        List<MovieCreator> GetAllMovies();
    }
}
