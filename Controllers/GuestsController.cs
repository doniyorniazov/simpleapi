using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private static List<GuestModel> guests = new()
        {
            new GuestModel { Id = 1, FirstName = "V2", LastName = "V2" },
            new GuestModel { Id = 1, FirstName = "Samuel", LastName = "Green" },
            new GuestModel { Id = 2, FirstName = "Sateshi", LastName = "Nakamoto" },
            new GuestModel { Id = 3, FirstName = "John", LastName = "Doe" }
        };

        // GET: api/<GuestsController>
        [HttpGet]
        public IEnumerable<GuestModel> Get()
        {
            Thread.Sleep(1000);
            return guests;
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public GuestModel Get(int id)
        {
            return guests.FirstOrDefault(g => g.Id == id);
        }

        // POST api/<GuestsController>
        [HttpPost]
        public void Post([FromBody] GuestModel value)
        {
            guests.Add(value);
        }

        // PUT api/<GuestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModel value)
        {
            guests.Remove(guests.FirstOrDefault(g => g.Id == id));
            guests.Add(value);
        }

        // DELETE api/<GuestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            guests.Remove(guests.FirstOrDefault(g => g.Id == id));
        }
    }
}
