using AutoMapper;
using NUnit.Framework;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using Service.Profiles;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Tests.Mocks;

namespace WebAPI.Tests.Service.Tests
{
    [TestFixture]
    class OfficeServiceTests
    {
        private IOfficeService _service;

        private Guid officeId = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650");
        private Guid wrongId = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54655");

        [SetUp]
        public void SetUpMock()
        {
            var repo = new OfficeRepoMock();

            var officeProfile = new OfficeProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(officeProfile));
            var mapper = new Mapper(configuration);

            _service = new OfficeService(repo, mapper);
        }

        [Test]
        public async Task OfficeService_GetAsync_ReturnsOfficesList()
        {
            var response = await _service.GetOfficesAsync();

            Assert.IsInstanceOf<List<OfficeResponse>>(response);
            Assert.That(response.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task OfficeService_GetAsyncById_ReturnsOfficeById()
        {
            var response = await _service.GetOfficeByIdAsync(officeId);

            Assert.IsInstanceOf<OfficeResponse>(response);
            Assert.That(response.Id, Is.EqualTo(officeId));
        }

        [Test]
        public async Task OfficeService_GetAsyncWrongId_ReturnsNull()
        {
            var response = await _service.GetOfficeByIdAsync(wrongId);

            Assert.That(response, Is.Null);
        }

        [Test]
        public async Task OfficeService_Update_ReturnsUpdatedOffice()
        {
            var response = await _service.UpdateOfficeAsync(officeId, new UpdateOfficeRequest {Name = "Updated" });

            Assert.IsInstanceOf<OfficeResponse>(response);
            Assert.That(response.Id, Is.EqualTo(officeId));
            Assert.That(response.Name, Is.EqualTo("Updated"));
        }
    }
}
