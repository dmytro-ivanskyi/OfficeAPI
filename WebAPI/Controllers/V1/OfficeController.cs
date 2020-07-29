using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ServiceInterfaces;

namespace WebAPI.Controllers.V1
{
    [Route("api/office")]
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _officeService.GetOfficesAsync());
        }


        [HttpGet("{officeId}")]
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
        [HttpGet("{officeId}/users")]
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfficeRequest createOffice)
        {
            var created = await _officeService.CreateOfficeAsync(createOffice);

            if (created == null)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/api/office/" + created.Id.ToString();

            return Created(location, created);
        }


        [HttpPut("{officeId}")]
        public async Task<IActionResult> Update([FromRoute] Guid officeId, [FromBody] UpdateOfficeRequest request)
        {
            var updatedOffice = await _officeService.UpdateOfficeAsync(officeId, request);

            if (updatedOffice != null)
                return Ok(updatedOffice);

            return NotFound();
        }


        [HttpDelete("{officeId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid officeId)
        {
            var deleted = await _officeService.DeleteOfficeAsync(officeId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
