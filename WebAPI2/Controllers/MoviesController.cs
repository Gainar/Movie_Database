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
            var MovieList = repo.GetAllMovies()
                                .OrderBy(f => f.Title);                                
            return MovieList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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
