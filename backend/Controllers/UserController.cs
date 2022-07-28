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

        [HttpPost]
        public IActionResult CreateUser(User u)
        {
            _service.CreateUser(u);
            return Ok(u);

        }

    }

}