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
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Models;

namespace SmartAgri.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _config = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserAuthDTO userAuthDTO)
        {
            var user = _userService.Authenticate(userAuthDTO.Username, userAuthDTO.Password);
            if (user == false)
                return BadRequest();

            var tokenString = GenerateJSONWebToken();

            return Ok(new { token = tokenString });
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterUserDTO userDTO)
        {
            User user = new User();
            user = MappUserDTOToUser(userDTO);
            user.PasswordSalt = Salt.Create();
            user.PasswordHash = Hash.Create(userDTO.Password, user.PasswordSalt);

            var check = _userService.Register(user);
            if (check==false)
            {
                return BadRequest("User already exists.");
            }
            return Ok();
        }

        private User MappUserDTOToUser(RegisterUserDTO userDTO)
        {
            User user = new User
            {
                Birthday = userDTO.Birthday,
                Email = userDTO.Email,
                PasswordSalt = Salt.Create(),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Sex = userDTO.Sex,
            };
            user.PasswordHash = Hash.Create(userDTO.Password, user.PasswordSalt);

            return user;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}