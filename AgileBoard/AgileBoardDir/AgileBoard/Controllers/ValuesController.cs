using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileBoard.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgileBoard.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static readonly List<Ticket> data;
        static ValuesController()
        {
            data = new List<Ticket>
            {
                new Ticket { Id = Guid.NewGuid().ToString(), Name="Task 1", Description="Make coffee" },
                new Ticket { Id = Guid.NewGuid().ToString(), Name="Task 2", Description="Eat something" },
            };
        }
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Ticket ticket)
        {
            ticket.Id = Guid.NewGuid().ToString();
            data.Add(ticket);
            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Ticket ticket = data.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            data.Remove(ticket);
            return Ok(ticket);
        }
    }
}
