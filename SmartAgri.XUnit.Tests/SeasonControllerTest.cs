using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartAgri.DataBase.Communication;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Controllers;
using SmartAgri.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAgri.XUnit.Tests
{
    public class SeasonControllerTest
    {
        private  ISeasonService _repo;

        public SeasonControllerTest()
        {
            _repo = new SeasonServiceMock();
        }

        [Fact]
        public void GetSeasons_ReturnsSeasons()
        {
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasons())
                .Returns(_repo.GetSeasons());

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.GetSeasons();

            var viewResult = Assert.IsType<OkObjectResult>(result);

            var model =  Assert.IsAssignableFrom<List<GetSeasonDTO>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }
        [Fact]
        public void GetSeasonById_ReturnsSeason()
        {
            int id = 2020;
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasonById(id))
                .Returns(_repo.GetSeasonById(id));

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.Get(id);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<GetSeasonDTO>(viewResult.Value);

            Assert.Equal(id, model.Id);
            Assert.Equal(200, viewResult.StatusCode);
        }

        [Fact]
        public void GetSeasonById_Returns404()
        {
            int id = 20220;
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasonById(id))
                .Returns(_repo.GetSeasonById(id));

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.Get(id);

            var viewResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, viewResult.StatusCode);
        }
    }
}
