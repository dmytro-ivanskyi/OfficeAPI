using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Service.Abstraction.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers.V1;
using WebAPI.Tests.Mocks;

namespace WebAPI.Tests.Controllers.Tests
{
    [TestFixture]
    public class OfficeControllerTest
    {
        private OfficeController _controller;

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

            Assert.IsInstanceOf<IActionResult>(response);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(officeList.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task Offices_GetById_IsOk()
        {
            var response = await _controller.Get(Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650"));
            var result = response as OkObjectResult;
            var officeValue = result.Value as OfficeResponse;

            Assert.IsInstanceOf<IActionResult>(response);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(officeValue.Id, Is.EqualTo(Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650")));
            Assert.That(officeValue.Name, Is.EqualTo("Headquerter"));
        }
    }
}
