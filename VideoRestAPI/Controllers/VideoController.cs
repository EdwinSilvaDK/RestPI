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
    [Route("api/[controller]")]
    public class VideoController : Controller

    {

        BLLFacade facade = new BLLFacade();
        // GET: api/Video
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoAppService.GetAll();
        }

        // GET api/Video/5
        [HttpGet("{id}")]
        public VideoBO Get(int id)
        {
            return facade.VideoAppService.Get(id);
        }

        // POST api/Video
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO vid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var video = facade.VideoAppService.Create(vid);
            return Ok(video);
        }

        // PUT api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO vid)
        {


            if (id != vid.Id)
            {
                return BadRequest("Path id does not match Video Id in json");
            }
            try
            {
                var video = facade.VideoAppService.Update(vid);
                return Ok(video);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }
        // DELETE api/Video/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoAppService.Delete(id);
        }
    }
}
