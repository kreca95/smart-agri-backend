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

        [Authorize]
        [HttpPost("anon")]
        public IActionResult GetActionResultAnonymous(UserAuthDTO userAuthDTO)
        {

            return Ok(userAuthDTO);
        }
    }
}