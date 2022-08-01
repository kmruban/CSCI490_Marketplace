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
        public IActionResult Login([FromBody] User u)
        {
            User obj = _service.Login(u);
            if (obj != null)
                return Ok(obj);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult RegisterUser(User u)
        {
            _service.RegisterUser(u);
            return Ok(u);
        }

        [HttpPut("{UserId}/update")]
        public IActionResult UpdateUser(int UserId, User userIn)
        {
            _service.UpdateUser(UserId, userIn);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            IEnumerable<User> list = _service.GetAllUsers();
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();
        }

        [HttpGet("{UserID}/userid")]
        public IActionResult GetUserByID(int UserID)
        {
            User obj = _service.GetUserByID(UserID);
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