using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.DataModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fitness.WebApi.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            var json = "{\"id\":1,\"first_name\":\"Brandice\",\"last_name\":\"Brownsett\",\"email\":\"bbrownsett0@washingtonpost.com\"}";
            var result = JsonConvert.DeserializeObject<UserModel>(json);
            return Ok(result);
        }
    }
}