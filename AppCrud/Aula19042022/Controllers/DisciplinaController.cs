using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aula19042022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        // GET: api/<DisciplinaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Matematica", "Inglês" };
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DisciplinaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
