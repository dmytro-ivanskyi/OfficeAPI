using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers.V1;
using WebAPI.Tests.Mocks;

namespace WebAPI.Tests.Controllers.Tests
{
    [TestFixture]
    public class OfficeControllerTest
    {
        private OfficeController _controller;
        private Guid officeId = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650");
        private Guid wrongId = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54655");

        [SetUp]
        public void SetUpMock()
        {
            
            var service = new OfficeServiceMock();

            _controller = new OfficeController(service);
        }

        [Test]
        public async Task Offices_Get_IsOk()
        {
            var response = await _controller.Get();
            var result = response as OkObjectResult;
            var officeList = result.Value as List<OfficeResponse>;

            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(officeList.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task Offices_GetById_IsOk()
        {
            var response = await _controller.Get(officeId);
            var result = response as OkObjectResult;
            var resultValue = result.Value as OfficeResponse;

            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(resultValue.Id, Is.EqualTo(officeId));
            Assert.That(resultValue.Name, Is.EqualTo("Headquarter"));
        }

        [Test]
        public async Task Offices_GetWrongId_ReturnsNotFound()
        {
            var response = await _controller.Get(wrongId);
            var result = response as NotFoundResult;

            Assert.That(result.StatusCode, Is.EqualTo(404));
        }

        public async Task Offices_GetIdWithUsers_IsOK()
        {
            var response = await _controller.GetWithUsers(officeId);
            var result = response as OkObjectResult;
            var resultValue = result.Value as OfficeWithUsersResponse;

            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(resultValue.Id, Is.EqualTo(officeId));
            Assert.That(resultValue.Name, Is.EqualTo("Headquarter"));
            Assert.IsInstanceOf<IEnumerable<UserShortResponse>>(resultValue.Users);
            Assert.That(resultValue.Users.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task Office_Create_ReturnsCreated()
        {
            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Scheme).Returns("https");
            request.Setup(x => x.Host).Returns(HostString.FromUriComponent("localhost:8000"));

            var httpContext = Mock.Of<HttpContext>(_ =>
                _.Request == request.Object
            );
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };
            _controller.ControllerContext = controllerContext;

            var response = await _controller.Create(new CreateOfficeRequest { Name = "New Office" });
            var result = response as CreatedResult;
            var resultValue = result.Value as OfficeResponse;

            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.That(resultValue.Name, Is.EqualTo("New Office"));
            Assert.That(resultValue.Id, Is.Not.Null);
        }

        [Test]
        public async Task Offices_CreateWithoutName_ReturnsBadRequest()
        {
            var response = await _controller.Create(new CreateOfficeRequest { Name = "" });
            var result = response as BadRequestResult;

            Assert.That(result.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public async Task Office_Update_ReturnsOk()
        {
            var response = await _controller.Update(officeId, new UpdateOfficeRequest { Name = "Updated"});
            var result = response as OkObjectResult;
            var resultValue = result.Value as OfficeResponse;

            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(resultValue.Id, Is.EqualTo(officeId));
            Assert.That(resultValue.Name, Is.Not.EqualTo("Headquarter"));
            Assert.That(resultValue.Name, Is.EqualTo("Updated"));
            
        }

        [Test]
        public async Task Office_UpdateWrongID_ReturnsNotFound()
        {
            var response = await _controller.Update(wrongId, new UpdateOfficeRequest { Name = "Updated" });
            var result = response as NotFoundResult;

            Assert.That(result.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public async Task Offices_Delete_ReturnsTrue()
        {
            var response = await _controller.Delete(officeId);
            var result = response as NoContentResult;

            Assert.That(result.StatusCode, Is.EqualTo(204));
        }

        [Test]
        public async Task Offices_DeleteWrongId_ReturnsFalse()
        {
            var response = await _controller.Delete(wrongId);
            var result = response as NotFoundResult;

            Assert.That(result.StatusCode, Is.EqualTo(404));
        }
    }
}
