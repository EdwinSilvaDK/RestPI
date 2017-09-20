using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using VideoAppBLL.BO;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Video
        [HttpGet]
        public IEnumerable<GenreBO> Get()
        {
            return facade.GenreService.GetAll();
        }

        // GET api/Video/5
        [HttpGet("{id}")]
        public GenreBO Get(int id)
        {
            return facade.GenreService.Get(id);
        }

        // POST api/Video
        [HttpPost]
        public IActionResult Post([FromBody]GenreBO gen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genre = facade.GenreService.Create(gen);
            return Ok(genre);
        }

        // PUT api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GenreBO gen)
        {


            if (id != gen.Id)
            {
                return BadRequest("Path id does not match Video Id in json");
            }
            try
            {
                var video = facade.GenreService.Update(gen);
                return Ok(video);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }
        // DELETE api/genre/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.GenreService.Delete(id);
        }

    }
}

