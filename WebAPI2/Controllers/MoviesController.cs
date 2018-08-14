using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI2.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/<controller>

        public IEnumerable<MovieCreator> Get()
        {
            var repo = new MovieRepository();
            return repo.GetAllMovies()
                       .OrderBy(f => f.Title);
        }

        // GET api/<controller>/5
        public MovieCreator Get(string tit)
        {
            var repo = new MovieRepository();
            return repo.GetMovie(tit);

        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]MovieCreator mov)
        {
            var repo = new MovieRepository();
            repo.AddMovie(mov);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
