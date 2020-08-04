using AutoMapper;
using Data.Abstraction.Models;
using Data.Abstraction.RepoInterfaces;
using Moq;
using NUnit.Framework;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ResponseModels;
using Service.Abstraction.ServiceInterfaces;
using Service.Profiles;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Tests.Service.Tests
{
    [TestFixture]
    class OfficeServiceTests
    {
        private readonly IOfficeService service;

        private Guid wrongId = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54655");
        private Guid officeId = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650");

        public OfficeServiceTests()
        {
            var officeProfile = new OfficeProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(officeProfile));
            var mapper = new Mapper(config);

            List<Office> offices = new List<Office>
            {
                new Office
                {
                Id = Guid.Parse("5114C24C-4571-48A2-6CD9-08D832E54650"),
                Name = "Headquarter",
                Users = new List<User>
                {
                    new User
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "John",
                        LastName = "Doe",
                        Age = 33
                    }
                }
                },
                new Office
                {
                    Id = Guid.Parse("B13C61AE-8137-4F15-AFFD-08D8330112C0"),
                Name = "Second Office"
                }
            };

            Mock<IOfficeRepo> repo = new Mock<IOfficeRepo>();

            repo.Setup(x => x.GetOfficesAsync())
                .Returns(Task.FromResult(offices));

            repo.Setup(x => x.GetOfficeByIdAsync(It.IsAny<Guid>()))
                .Returns((Guid id) => Task.FromResult(offices.Where(x => x.Id == id).FirstOrDefault()));

            repo.Setup(x => x.CreateOfficeAsync(It.IsAny<Office>()))
                .Returns((Office target) =>
            {
                if (target.Name == string.Empty)
                    return Task.FromResult(false);

                target.Id = Guid.NewGuid();
                offices.Add(target);
                return Task.FromResult(true);
            });

            repo.Setup(x => x.UpdateOfficeAsync(It.IsAny<Office>()))
                .Returns((Office target) =>
             {
                 var officeToUpdate = offices.Find(x => x.Id == target.Id);
                 if(officeToUpdate == null)
                     return Task.FromResult(false);

                 officeToUpdate.Name = target.Name;
                 return Task.FromResult(true);
             });

            repo.Setup(x => x.GetOfficeByIdWithUsersAsync(It.IsAny<Guid>()))
                .Returns((Guid id) => Task.FromResult(offices.Where(x => x.Id ==  id).FirstOrDefault()));

            repo.Setup(x => x.DeleteOfficeAsync(It.IsAny<Guid>()))
                .Returns((Guid id) =>
                {
                    var officeToDelete = offices.Find(x => x.Id == id);
                    if (officeToDelete == null)
                        return Task.FromResult(false);

                    offices.Remove(officeToDelete);
                    return Task.FromResult(true);
                });

            service = new OfficeService(repo.Object, mapper);
        }

        [Test]
        public async Task OfficeService_GetAsync_ReturnsOfficesList()
        {
            var response = await service.GetOfficesAsync();

            Assert.IsInstanceOf<List<OfficeResponse>>(response);
            Assert.That(response.Count, Is.Not.Zero);
        }

        [Test]
        public async Task OfficeService_GetAsyncById_ReturnsOfficeById()
        {
            var response = await service.GetOfficeByIdAsync(officeId);

            Assert.IsInstanceOf<OfficeResponse>(response);
            Assert.That(response.Id, Is.EqualTo(officeId));
        }

        [Test]
        public async Task OfficeService_GetAsyncWrongId_ReturnsNull()
        {
            var response = await service.GetOfficeByIdAsync(wrongId);

            Assert.That(response, Is.Null);
        }

        [Test]
        public async Task OfficeService_Update_ReturnsUpdatedOffice()
        {
            var response = await service.UpdateOfficeAsync(officeId, new UpdateOfficeRequest { Name = "Updated" });

            Assert.IsInstanceOf<OfficeResponse>(response);
            Assert.That(response.Id, Is.EqualTo(officeId));
            Assert.That(response.Name, Is.EqualTo("Updated"));
        }

        [Test]
        public async Task OfficeService_UpdateWrongId_ReturnsNull()
        {
            var response = await service.UpdateOfficeAsync(wrongId, new UpdateOfficeRequest { Name = "Updated" });

            Assert.That(response, Is.Null);
        }

        [Test]
        public async Task OfficeService_Create_ReturnsNewOffice()
        {
            var response = await service.CreateOfficeAsync(new CreateOfficeRequest { Name = "New Office" });

            Assert.IsInstanceOf<OfficeResponse>(response);
            Assert.IsInstanceOf<Guid>(response.Id);
            Assert.That(response.Id, Is.Not.EqualTo(default(Guid)));
            Assert.That(response.Name, Is.EqualTo("New Office"));
        }

        [Test]
        public async Task OfficeService_CreateWithoutName_ReturnsNull()
        {
            var response = await service.CreateOfficeAsync(new CreateOfficeRequest { Name = "" });

            Assert.That(response, Is.Null);
        }

        [Test]
        public async Task OfficeService_Delete_ReturnsTrue()
        {
            var response = await service.DeleteOfficeAsync(Guid.Parse("B13C61AE-8137-4F15-AFFD-08D8330112C0"));

            Assert.That(response, Is.True);
        }

        [Test]
        public async Task OfficeService_DeleteWrongId_ReturnsFalse()
        {
            var response = await service.DeleteOfficeAsync(wrongId);

            Assert.That(response, Is.False);
        }
    }
}
