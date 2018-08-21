﻿using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
