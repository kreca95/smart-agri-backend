using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Controllers.Helpers;
using SmartAgri.Web.Helpers;
using SmartAgri.Web.Models;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IConfiguration configuration, IUserService userService,ITokenService tokenService)
        {
            _config = configuration;
            _userService = userService;
            _tokenService = tokenService;
        }
        #region description
        /// <summary>
        /// Validates user credentials and generates JWT
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/user/login
        ///
        /// </remarks>
        /// <returns>Return JWT if credentials are correct</returns>
        /// <param name="userAuthDTO"></param>
        /// <response code="200">Login successful</response>
        /// <response code="400">If the item exists or input is invalid</response>   
        /// 
#endregion
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserAuthDTO userAuthDTO)
        {
            try
            {
                var user = _userService.Authenticate(userAuthDTO.Username, userAuthDTO.Password);
                if (user == null)
                    return BadRequest();
                var tokenString = _tokenService.GenerateToken(user, _config);
                var tokenresponse = new TokenResponse { Token = tokenString.Token, RefreshToken = tokenString.RefreshToken };
                return Ok(tokenresponse);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        #region description
        /// <summary>
        /// Validates user credentials and inserts a user to db
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/user/register
        ///
        /// </remarks>
        /// <returns>Return JWT if credentials are correct</returns>
        /// <param name="userDTO"></param>
        /// <response code="201">Created user</response>
        /// <response code="400">If the item exists or input is invalid</response>   
        /// 
        #endregion
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterUserDTO userDTO)
        {
            try
            {
                var errors = Validation.ValidatePassword(userDTO.Password);
                if (errors.Count > 0)
                {
                    return BadRequest(errors);
                }
                if (!Validation.IsValidEmail(userDTO.Email))
                {
                    return BadRequest("Email is not valid.");
                }
                User user = new User();
                user = Mapper.MappUserDTOToUser(userDTO);
                user.PasswordSalt = Salt.Create();
                user.PasswordHash = Hash.Create(userDTO.Password, user.PasswordSalt);

                var check = _userService.Register(user);
                if (check == false)
                {
                    return BadRequest("User already exists.");
                }
                // umjesto ok stavit createdAt i ispravit u testovima
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                if (users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound("No users were found.");
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Headers["refresh-token"].ToString();
            _tokenService.GenerateRefreshToken();
            return Ok();
        }

    }
}