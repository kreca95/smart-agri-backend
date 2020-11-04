using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Controllers.Helpers;
using SmartAgri.Web.Models;
using System;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _fieldService;
        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }
        #region description
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
        /// 
        #endregion
        [HttpPost]
        public IActionResult UpsertField(UpsertFieldDTO field)
        {
            try
            {
                //Field fieldMapped = _mapper.Map<Field>(field);
                Field fieldMapped = Mapper.MappField(field);
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
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }


        #region description
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
        /// 
        #endregion
        [HttpGet]
        [Route("{year}")]
        public IActionResult GetFiledsBySeasonId(int year)
        {
            try
            {
                string fields = _fieldService.GetFieldsBySeasonYear(year);

                GetFiledsBySeasonId geom = JsonConvert.DeserializeObject<GetFiledsBySeasonId>(fields);

                if (geom.type.Equals(null))
                {
                    return NotFound();
                }
                return Ok(geom);
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }



    }
}