using Model.Models;
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
        [Route("api/movies/")]
        public IHttpActionResult Add([FromBody] Movies data)
        {
            MoviesService service = new MoviesService();
            data.created_at = DateTime.Now;
            var response = service.Add(data);
            return Ok(response);
        }

        [HttpPatch]
        [Route("api/movies")]
        public IHttpActionResult Update([FromBody] Movies data)
        {
            MoviesService service = new MoviesService();
            data.updated_at = DateTime.Now;
            var response = service.Update(data);
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/movies/{id}")]
        public IHttpActionResult Delete(int id)
        {
            MoviesService service = new MoviesService();
            var response = service.Delete(id);
            return Ok(response);
        }
    }
}
