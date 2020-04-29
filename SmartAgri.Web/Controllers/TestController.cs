using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("anon")]
        public IActionResult GetActionResultAnonymous()
        {
            return Ok();
        }
        [Authorize]
        [HttpGet("auth")]
        public IActionResult GetActionResultAuth()
        {
            return Ok();
        }
    }
}