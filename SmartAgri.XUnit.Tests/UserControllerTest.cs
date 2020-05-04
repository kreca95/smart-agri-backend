using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.Web.Controllers;
using SmartAgri.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SmartAgri.XUnit.Tests
{
    public class UserControllerTest
    {
        private readonly IUserService _repo;

        public UserControllerTest()
        {
            _repo = new UserServiceMock();
        }

        [Fact]
        public void RegisterUser_RegistersUserPasswordTest_Returns201()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var controller = new UserController(configuration, _repo);
            var model = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "slovoVeliko1",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(model);

            Assert.IsType<OkResult>(a);

        }

        #region testovi za validaciju passworda
        [Fact]
        public void RegisterUser_NoDigitPassword_Returns400()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "slovoVeliko",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Single(model);
        }

        [Fact]
        public void RegisterUser_NoUpperCasePassword_Returns400()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "slovoeliko1",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Single(model);
        }
        [Fact]
        public void RegisterUser_NoLowerCasePassword_Returns400()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "HUYAHOP123",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Single(model);
        }

        [Fact]
        public void RegisterUser_MinLengthPassIs8_Returns400()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "kratka",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Single(model);
        }

        [Fact]
        public void RegisterUser_MaxLengthPassIs15_Returns400()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "slovo21321321321321321321Veliko",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Single(model);
        }

        [Fact]
        public void RegisterUser_NoLowerNoUpper_Returns400()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "123456789",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void RegisterUser_NoLowerNoDigit_Returns400()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "HUYABOAAA",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void RegisterUser_NoLowerTooShort_Returns400()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var controller = new UserController(configuration, _repo);
            var viewmodel = new RegisterUserDTO
            {
                Email = "kresimir@kreso.ba",
                Password = "ASD123",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(viewmodel);

            var viewResult = Assert.IsType<BadRequestObjectResult>(a);
            var model = Assert.IsAssignableFrom<List<string>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }
        #endregion

        [Fact]
        public void RegisterUser_InvalidEmail_Returns400()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var controller = new UserController(configuration, _repo);
            var model = new RegisterUserDTO
            {
                Email = "kresimirkreso.ba",
                Password = "slovoVeliko",
                FirstName = "kreso",
                LastName = "sutalo",
                Birthday = new DateTime(1995, 10, 4, 0, 0, 0, 0)
            };
            var a = controller.Register(model);

            Assert.IsType<BadRequestObjectResult>(a);
        }

    }
}
