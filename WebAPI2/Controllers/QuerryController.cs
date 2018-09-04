using System.Collections.Generic;
using System.Web.Http;
using DAL.Repository;
using Movie.Core.Models;

namespace WebAPI2.Controllers
{
    public class QuerryController : ApiController
    {
        //GET api/<controller>/<param>
        [Route("api/Querry/{param}")]
        public List<MovieCreator> GET(string param)
        {
            var repo = new MovieRepository();
            return repo.Querry(param);

        }

        // GET api/<controller>/<param>/<val>
        [Route("api/Querry/{param}/{val}")]
        public List<MovieCreator> Get(string param, string val)
        {
            var repo = new MovieRepository();
            return repo.Querry(param, val);

        }
    }
}
