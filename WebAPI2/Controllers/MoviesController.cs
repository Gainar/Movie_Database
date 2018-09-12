using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Repository;
using Movie.Core.Models;
using Ninject;


namespace WebAPI2.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieRepository repo;

        //public MoviesController()
        //{
        //        repo=new MovieRepository();
        //}

        public MoviesController()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IMovieRepository>().To<MovieRepository>();
            repo = kernel.Get<IMovieRepository>();
        }
        // GET api/<controller>
        [Route ("api/Movies")]
        public IEnumerable<MovieCreator> Get()
        {
            return repo.GetAllMovies()
                       .OrderBy(f => f.Title);
        }

        // GET api/<controller>/5
        [Route ("api/Movies/{tit}")]
        public MovieCreator Get(string tit)
        {
            return repo.GetMovie(tit);
        }
              

        // POST api/<controller>
        [Route ("api/Movies")]
        public HttpResponseMessage Post([FromBody]MovieCreator mov)
        {
            repo.AddMovie(mov);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        

        // PUT api/<controller>/5
        [Route ("api/Movies/{tit}")]
        public void Put([FromBody]MovieCreator mov)
        {
            repo.EditMovie(mov);
        }

        // DELETE api/<controller>/5
        [Route ("api/Movies/{tit}/Delete")]
        public void Delete(string tit)
        {
            repo.DeleteByTitleMovie(tit);
        }
    }
}
