using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgriCropSpecController : ControllerBase
    {
        private readonly IAgriCropSpecsService _agriCropSpecsService;

        public AgriCropSpecController(IAgriCropSpecsService agriCropSpecsService)
        {
            this._agriCropSpecsService = agriCropSpecsService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var crop = _agriCropSpecsService.GetAgriCropSpec(id);
                if (crop == null)
                {
                    return NotFound();
                }
                return Ok(crop);
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost]
        public IActionResult Insert(AgriCropSpec agriCropSpec)
        {
            try
            {
                var check = _agriCropSpecsService.Insert(agriCropSpec);
                if (check)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var specs = _agriCropSpecsService.GetAgriCropSpecs();
                if (specs.Count < 1 || specs == null)
                {
                    return NotFound();
                }
                return Ok(specs);
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var check=_agriCropSpecsService.Delete(id);
                if (check)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPatch]
        public IActionResult Update(AgriCropSpec agriCropSpec)
        {
            try
            {
                var check = _agriCropSpecsService.Update(agriCropSpec);
                if (check)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}