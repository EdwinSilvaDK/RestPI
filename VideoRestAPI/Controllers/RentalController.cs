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
    public class RentalController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Video
        [HttpGet]
        public IEnumerable<RentalBO> Get()
        {
            return facade.RentalService.GetAll();
        }

        // GET api/Video/5
        [HttpGet("{id}")]
        public RentalBO Get(int id)
        {
            return facade.RentalService.Get(id);
        }

        // POST api/Video
        [HttpPost]
        public IActionResult Post([FromBody]RentalBO Ren)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Rental = facade.RentalService.Create(Ren);
            return Ok(Rental);
        }

        // PUT api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RentalBO Ren)
        {


            if (id != Ren.Id)
            {
                return BadRequest("Path id does not match rental Id in json");
            }
            try
            {
                var rental = facade.RentalService.Update(Ren);
                return Ok(rental);
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
            facade.RentalService.Delete(id);
        }
    }
}
