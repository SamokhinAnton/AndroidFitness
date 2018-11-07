using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.EntityBase;
using Fitness.EntityBase.Entities.dbo;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly FitnessContext _context;

        public ValuesController(FitnessContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            var roles = _context.Roles.Select(r => r.Role).ToList();
            var users = _context.Users.Where(u => u.Role.Id == 1).Select(u => u.Name).ToList();
            return users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value = {id}";
        }
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// /// <param name="value"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>     
        // POST api/values
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"> removing item id // int </param>    
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
