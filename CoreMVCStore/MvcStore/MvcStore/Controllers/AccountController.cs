using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> aUserManager)
        {
            userManager = aUserManager;
        }

        //Returning a JWT token
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]Register register)
        {
            var user = new User
            {
                UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email                
            };

            var results = await userManager.CreateAsync(user, register.Password);
            if (!results.Succeeded)
            {
                return BadRequest(results.Errors);
            }

            var token = new JwtSecurityToken();

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}