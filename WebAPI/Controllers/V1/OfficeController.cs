using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts.V1;
using WebAPI.Contracts.V1.Requests;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.ServiceInterfaces;

namespace WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet(ApiRoutes.Offices.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _officeService.GetOffices());
        }

        [HttpGet(ApiRoutes.Offices.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid officeId)
        {
            var office = await _officeService.GetOfficeById(officeId);
            if (office == null)
                return NotFound();

            return Ok(office);
        }

        [HttpPost(ApiRoutes.Offices.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOfficeRequest createOffice)
        {
            var office = new Office
            {
                Name = createOffice.Name
            };

            var created = await _officeService.CreateOffice(office);
            if (!created)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/" + ApiRoutes.Offices.Get.Replace("{officeId}", office.Id.ToString());

            var response = new OfficeResponse
            {
                Id = office.Id,
                Name = office.Name
            };
            return Created(location, response);
        }

        [HttpPut(ApiRoutes.Offices.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid officeId, [FromBody] UpdateOfficeRequest request)
        {
            var office = new Office
            {
                Id = officeId,
                Name = request.Name
            };

            var updated =  await _officeService.UpdateOffice(office);

            if (updated)
                return Ok(office);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Offices.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid officeId)
        {
            var deleted = await _officeService.DeleteOffice(officeId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
