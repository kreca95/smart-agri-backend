using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.Web.Models;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public IActionResult GetActionResultAnonymous()
        {
            var a = Request;
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAction()
        {
            var a=Request;
            return Ok();
        }
    }
}