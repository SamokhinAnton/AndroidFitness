using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.DataModels.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fitness.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            //var json = "{\"id\":1,\"first_name\":\"Brandice\",\"last_name\":\"Brownsett\",\"email\":\"bbrownsett0@washingtonpost.com\"}";
            //var result = JsonConvert.DeserializeObject<UserModel>(json);
            var user = new UserModel() { Email = "bbrownsett0@washingtonpost.com", Id = 3, FirstName = "Brandice", LastName = "Brownsett" };
            return Ok(user);
        }
    }
}