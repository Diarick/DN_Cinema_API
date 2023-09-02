﻿using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class MoviesController : ApiController
    {
        [HttpGet]
        [Route("api/movies")]
        public IHttpActionResult GetList()
        {
            MoviesService service = new MoviesService();
            List<Movies> Datas = service.GetList();
            return Ok(Datas);
        }

        [HttpGet]
        [Route("api/movies/{id}")]
        public IHttpActionResult GetSingle(int id)
        {
            MoviesService service = new MoviesService();
            Movies Data = service.GetSingle(id); 
            return Ok(Data);
        }

        [HttpPost]
        [Route("api/movies/add")]
        public IHttpActionResult Add([FromBody] Movies data)
        {
            MoviesService service = new MoviesService();
            var response = service.Add(data);
            return Ok(response);
        }

        [HttpPatch]
        [Route("api/movies/update")]
        public IHttpActionResult Update([FromBody] Movies data)
        {
            MoviesService service = new MoviesService();
            var response = service.Update(data);
            return Ok(response);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}