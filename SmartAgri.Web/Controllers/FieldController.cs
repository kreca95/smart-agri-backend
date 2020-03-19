using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartAgri.DataBase.Communication;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Models;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _fieldService;
        private readonly IMapper _mapper;
        public FieldController(IFieldService fieldService, IMapper mapper)
        {
            _fieldService = fieldService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/field
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "geom": null,
        ///         "nasIme": null,
        ///          "seasonId": 0,
        ///          "fieldId": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="field"></param>
        /// <returns>A newly created field</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        public IActionResult UpsertField(UpsertFieldDTO field)
        {
            Field fieldMapped = _mapper.Map<Field>(field);
            //fieldMapped.Geom_ = JsonConvert.DeserializeObject<Geom>(field.Geom);
            if (ModelState.IsValid)
            {
                var check = _fieldService.UpsertField(fieldMapped);
                if (check)
                {
                    Ok(field);
                }
            }
            return BadRequest();
        }


        /// <summary>
        /// Gets fields by year.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/field/{id}
        ///     {
        ///        "year": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="year"></param>
        /// <returns>A newly created field</returns>
        /// <response code="200">Returns fields of a year</response>
        /// <response code="404">If the item is null</response>   
        [HttpGet]
        [Route("{year}")]
        public IActionResult GetFiledsBySeasonId(int year)
        {
            string fields = _fieldService.GetFieldsBySeasonYear(year);

            GetFiledsBySeasonId geom = JsonConvert.DeserializeObject<GetFiledsBySeasonId>(fields);

            if (geom.type.Equals(null))
            {
                return NotFound();
            }
            return Ok(geom);
        }
    }
}