using System.Collections.Generic;
using System.Threading.Tasks;
using Movie.Core.Models;

namespace Movie.Proxy.Proxy
{
    public interface IDesktop
    {
        Task<List<MovieCreator>> View();
        void Add(MovieCreator mov);
        void Delete(string tit);
        void Edit(MovieCreator mov);
    }
}
