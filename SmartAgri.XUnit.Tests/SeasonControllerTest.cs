using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartAgri.DataBase.Communication;
using SmartAgri.DataBase.Models.Models;
using SmartAgri.Web.Controllers;
using SmartAgri.Web.Models;
using System.Collections.Generic;
using Xunit;

namespace SmartAgri.XUnit.Tests
{
    public class SeasonControllerTest
    {
        private readonly ISeasonService _repo;

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

            var model = Assert.IsAssignableFrom<List<GetSeasonDTO>>(viewResult.Value);
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
        [Fact]
        public void GetSeasonById_ReturnsBadRequest()
        {
            int id = 0;
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasonById(id))
                .Returns(_repo.GetSeasonById(id));

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.Get(id);

            var viewResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, viewResult.StatusCode);
        }

        [Fact]
        public void GetSeasonByYear_ReturnsOK()
        {
            int id = 2019;
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasonByYear(id))
                .Returns(_repo.GetSeasonByYear(id));

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.GetSeasonByYear(id);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, viewResult.StatusCode);
        }
        [Fact]
        public void GetSeasonByYear_ReturnsBadRequest()
        {
            int id = 0;
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasonByYear(id))
                .Returns(_repo.GetSeasonByYear(id));

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.GetSeasonByYear(id);

            var viewResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, viewResult.StatusCode);
        }
        [Fact]
        public void GetSeasonByYear_ReturnsNotFound()
        {
            int id = -1;
            var mockRepo = new Mock<ISeasonService>();

            mockRepo.Setup(repo => repo.GetSeasonByYear(id))
                .Returns(_repo.GetSeasonByYear(id));

            var controller = new SeasonController(mockRepo.Object);

            var result = controller.GetSeasonByYear(id);

            var viewResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, viewResult.StatusCode);
        }
        [Fact]
        public void UpsertSeason_ReturnsCreatedAtRoute()
        {
            //arange
            SeasonController controller = new SeasonController(_repo);
            UpsertSeasonDTO season = new UpsertSeasonDTO() { Id = -1, Name = "-1" };

            //act
            var data = controller.UpsertSeason(season);

            //assert
            Assert.IsType<CreatedAtRouteResult>(data);
        }
        [Fact] 
        public void UpsertSeason_Null_ReturnsBadRequest()
        {
            //arange
            SeasonController controller = new SeasonController(_repo);
            UpsertSeasonDTO season = new UpsertSeasonDTO() ;

            //act
            var data = controller.UpsertSeason(null);

            //assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public void DeleteSeason_ReturnsOK()
        {
            SeasonController controller = new SeasonController(_repo);
            var id = 2020;
            //act
            var data = controller.DeleteSeason(id);

            //assert
            Assert.IsType<OkResult>(data);
        }
        [Fact]
        public void DeleteSeason_ReturnsNotFound()
        {
            SeasonController controller = new SeasonController(_repo);
            var id = 1;
            //act
            var data = controller.DeleteSeason(id);

            //assert
            Assert.IsType<NotFoundResult>(data);
        }
    }
}
