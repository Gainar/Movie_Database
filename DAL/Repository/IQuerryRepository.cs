using System.Collections.Generic;
using Movie.Core.Models;

namespace DAL.Repository
{
    public interface IQuerryRepository
    {
        List<MovieCreator> Querry(string param, string val);
        List<MovieCreator> Querry(string param);
    }
}