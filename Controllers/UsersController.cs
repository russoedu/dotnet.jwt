using Microsoft.AspNetCore.Mvc;
using dotnet.jwt.Services;
using dotnet.jwt.Models;
using System;

namespace dotnet.jwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null) {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
