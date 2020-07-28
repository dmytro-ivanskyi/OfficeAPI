using System;
using System.Threading.Tasks;
using Data.Abstraction.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.ServiceInterfaces;
using WebAPI.Contracts.V1;
using WebAPI.Contracts.V1.Requests;

namespace WebAPI.Controllers.V1
{
    // [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }


        /// <summary>
        /// Returns all offices
        /// </summary>
        [HttpGet(ApiRoutes.Offices.GetAll)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _officeService.GetOfficesAsync());
        }


        [HttpGet(ApiRoutes.Offices.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid officeId)
        {
            var office = await _officeService.GetOfficeByIdAsync(officeId);

            if (office == null)
                return NotFound();

            return Ok(office);
        }


        /// <summary>
        /// Returns all users in an office
        /// </summary>
        [HttpGet(ApiRoutes.Offices.Get+"/users")]
        public async Task<IActionResult> GetWithUsers([FromRoute] Guid officeId)
        {
            var office = await _officeService.GetOfficeByIdWithUsersAsync(officeId);

            if (office == null)
                return NotFound();

            return Ok(office);
        }


        /// <summary>
        /// Creates office
        /// </summary>
        /// <response code="201">Office created succesfully</response>
        /// <response code="400">Unable to create</response>
        [HttpPost(ApiRoutes.Offices.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOfficeRequest createOffice)
        {
            var office = new Office
            {
                Name = createOffice.Name
            };

            var created = await _officeService.CreateOfficeAsync(office);
            if (!created)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/" + ApiRoutes.Offices.Get.Replace("{officeId}", office.Id.ToString());

            return Created(location, new { Message = "Office Created"});
        }


        [HttpPut(ApiRoutes.Offices.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid officeId, [FromBody] UpdateOfficeRequest request)
        {
            var office = new Office
            {
                Id = officeId,
                Name = request.Name
            };

            var updated = await _officeService.UpdateOfficeAsync(office);

            if (updated)
                return Ok(office);

            return NotFound();
        }


        [HttpDelete(ApiRoutes.Offices.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid officeId)
        {
            var deleted = await _officeService.DeleteOfficeAsync(officeId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
