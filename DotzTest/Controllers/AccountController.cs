using System;
using System.Collections.Generic;
using System.Linq;
using DotzTest.Models;
using DotzTest.Services;
using DotzTest.Web.Data.FormData;
using Microsoft.AspNetCore.Mvc;

namespace DotzTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login([FromBody]LoginFormData login)
        {
            var user = new UserModel();
            user.Name = login.Username;
            user.Role = "user";
            user.Id = Guid.NewGuid();

            var token = TokenService.GenerateToken(user);
            return new {
                user = user,
                token = token
            };
        }
    }
}