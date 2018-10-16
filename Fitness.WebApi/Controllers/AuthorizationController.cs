using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.DataModels.Entities.Users;
using Fitness.WebApi.Utilities.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fitness.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        public IJWTAuthHelper<UserModel> AuthHelper { get; set; }

        public AuthorizationController(IJWTAuthHelper<UserModel> authHelper)
        {
            AuthHelper = authHelper;
        }

        [HttpGet("create")]
        public IActionResult Index()
        {
            var user = new UserModel() { Email = "bbrownsett0@washingtonpost.com", Id = 3, FirstName = "Brandice", LastName = "Brownsett", Role = "admin" };
            var token = AuthHelper.Create(Request, user);
            return Ok(token);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            var claims = User.Claims.Select(c =>
                new
                {
                    Type = c.Type,
                    Value = c.Value
                });
            return Ok(claims);
        }

        [HttpDelete]
        public IActionResult EmptyAttributes()
        {
            return BadRequest();
        }
    }
}