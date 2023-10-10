using Microsoft.AspNetCore.Mvc;

namespace events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventsController : ControllerBase
    {
        static int i = 3;
        static List<Events> eve = new List<Events> { new Events { Id = 1, Title = "a", Start = new DateTime(2023, 09, 01, 9, 15, 0), End = new DateTime(2023, 09, 01, 9, 15, 0) }, new Events { Id = 2, Title = "b", Start = new DateTime(2023, 09, 02, 9, 15, 0), End = new DateTime(2023, 09, 02, 9, 15, 0) }, new Events { Id = 3, Title = "c",Start = new DateTime(2023, 09, 03, 9, 15, 0), End= new DateTime(2023, 09, 03, 9, 15, 0) } };

        [HttpGet]
        public IEnumerable<Events> Get()
        {
            return eve;
        }


        [HttpPost]
        public void Post([FromBody] Events e)
        {
            eve.Add(new Events { Id = ++i, Title = e.Title, Start = e.Start, End = e.End });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Events ev)
        {
            foreach (Events e in eve)
            {
                if (e.Id == id)
                {
                    e.Start = ev.Start;
                    e.End = ev.End;
                    e.Title = ev.Title;
                }
            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (Events e in eve)
            {
                if (e.Id == id)
                {
                    eve.Remove(e);
                    break;
                }
            }
        }
    }
}
