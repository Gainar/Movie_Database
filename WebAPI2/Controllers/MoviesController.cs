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
        [Route ("api/Movies")]
        public IEnumerable<MovieCreator> Get()
        {
            var repo = new MovieRepository();
            return repo.GetAllMovies()
                       .OrderBy(f => f.Title);
        }

        // GET api/<controller>/5
        [Route ("api/Movies/{tit}")]
        public MovieCreator Get(string tit)
        {

            var repo = new MovieRepository();
            return repo.GetMovie(tit);

        }
              

        // POST api/<controller>
        [Route ("api/Movies")]
        public HttpResponseMessage Post([FromBody]MovieCreator mov)
        {
            var repo = new MovieRepository();
            repo.AddMovie(mov);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        

        // PUT api/<controller>/5
        [Route ("api/Movies/{tit}")]
        public void Put([FromBody]MovieCreator mov)
        {
            var repo = new MovieRepository();
            repo.EditMovie(mov);
        }

        // DELETE api/<controller>/5
        [Route ("api/Movies/{tit}/Delete")]
        public void Delete(string tit)
        {
            var repo = new MovieRepository();
            repo.DeleteByTitleMovie(tit);
        }
    }
}
