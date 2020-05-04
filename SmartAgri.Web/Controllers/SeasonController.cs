using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.DataBase.Communication;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Controllers.Helpers;
using SmartAgri.Web.Models;

namespace SmartAgri.Web.Controllers
{
    //fali sortiranje,paginacija

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _DB;
        public SeasonController(ISeasonService db)
        {
            _DB = db;
        }

        /// <summary>
        /// Gets all seasons.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/season
        ///
        /// </remarks>
        /// <returns>Returns seasons</returns>
        /// <response code="200">Returns seasons </response>
        /// <response code="404">If the item is null</response>   
        [HttpGet]
        public IActionResult GetSeasons()
        {
            var seasons = _DB.GetSeasons();

            //var mapped = _mapper.Map<List<GetSeasonDTO>>(seasons);
            var mapped = Mapper.MappGetSeasonDTO(seasons);
            if (seasons == null || seasons.Count < 1)
            {
                return NotFound();
            }

            return Ok(mapped);
        }



        /// <summary>
        /// Gets seasony by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/season/{id}
        ///
        /// </remarks>
        /// <returns>Returns season</returns>
        /// <param name="id"></param>
        /// <response code="200">Returns season</response>
        /// <response code="404">If the item is null</response>   
        [HttpGet("{id}", Name = "GetSeason")]
        public IActionResult Get(int id)
        {
            if (id != 0)
            {
                var a = _DB.GetSeasonById(id);
                //var mapped = _mapper.Map<GetSeasonDTO>(a);
                if (a == null)
                {
                    return NotFound("Season not found.");
                }
                GetSeasonDTO mapped = Mapper.MappGetSeasonDTO(new List<Season> { new Season { Id = a.Id, Name = a.Name, Deleted = a.Deleted } }).FirstOrDefault();


                return Ok(mapped);
            }
            else
            {
                return BadRequest("Invalid id.");
            }
        }
        /// <summary>
        /// Gets seasony by year.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/season/year/{year}
        ///
        /// </remarks>
        /// <returns>Returns season</returns>
        /// <param name="year"></param>
        /// <response code="200">Returns season</response>
        /// <response code="404">If the item is null</response>   
        [HttpGet("year/{year}")]
        public IActionResult GetSeasonByYear(int year)
        {
            if (year != 0)
            {
                List<Season> seasons = _DB.GetSeasonByYear(year);
                //var mapped=_mapper.Map<List<GetSeasonDTO>>(seasons);
                var mapped = Mapper.MappGetSeasonDTO(seasons);
                if (seasons.Count > 0)
                {
                    return Ok(mapped);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("Invalid year.");
            }
        }

        /// <summary>
        /// Creates or updates season
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/season
        ///
        /// </remarks>
        /// <returns>Returns season</returns>
        /// <param name="season"></param>
        /// <response code="201">Created season</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        //provjerit name i id postoje li vec
        public IActionResult UpsertSeason([FromBody] UpsertSeasonDTO season)
        {
            if (ModelState.IsValid && season!=null)
            {
                //var mapped = _mapper.Map<Season>(season);

                Season mapped = Mapper.MappSeasonFromUpsertSeasonDTO(season);

                bool check = _DB.InsertSeason(mapped);

                if (check)
                {
                    return CreatedAtRoute("GetSeason", new { id = season.Id }, season);
                }
            }
            return BadRequest();
        }


        /// <summary>
        /// Deletes a season.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/season
        ///
        /// </remarks>
        /// <returns>Returns season</returns>
        /// <param name="id"></param>
        /// <response code="200">Deleted season</response>
        /// <response code="400">If the item is null</response>   

        [HttpDelete("{id}")]
        public IActionResult DeleteSeason(int id)
        {
            if (id != 0)
            {
                bool check = _DB.DeleteSeason(id);
                if (check)
                {
                    return Ok();
                }
            }
            return NotFound();
        }


      
    }
}