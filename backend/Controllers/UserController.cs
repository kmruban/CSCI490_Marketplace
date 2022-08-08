using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketPlace.Models;
using MarketPlace.Services;

namespace MarketPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserServices _service;
        public UserController(ILogger<UserController> logger, IUserServices services)
        {
            _logger = logger;
            _service = services;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User u)
        {
            User obj = await _service.Login(u);
            if (obj != null)
                return Ok(obj);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult RegisterUser(User u)
        {
            _service.RegisterUser(u);
            Console.WriteLine(u);
            return Ok(u);
        }

        [HttpPut("{UserId}/update")]
        public IActionResult UpdateUser(int UserId, User userIn)
        {
            _service.UpdateUser(UserId, userIn);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            IList<User> list = await _service.GetAllUsers();
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();
        }

        [HttpGet("{UserID}/userid")]
        public async Task<IActionResult> GetUserByID(int UserID)
        {
            User obj = await _service.GetUserByID(UserID);
            if (obj != null)
                return Ok(obj);

            return BadRequest();
        }

        [HttpDelete("{UserID}")]
        public IActionResult DeleteUser(int UserID)
        {
            _service.DeleteUser(UserID);
            return NoContent();
        }

    }

}