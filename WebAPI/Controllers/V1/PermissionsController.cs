using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ServiceInterfaces;

namespace WebAPI.Controllers.V1
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IUserPermissionService _userPermissionService;

        public PermissionsController(IPermissionService service, IUserPermissionService userPermissionService)
        {
            _permissionService = service;
            _userPermissionService = userPermissionService;
        }


        // GET: api/permissions
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            return Ok(await _permissionService.GetPermissionsAsync());
        }


        // GET: api/permissions/5
        [HttpGet("{permissionId}")]
        public async Task<IActionResult> GetPermission(Guid permissionId)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(permissionId);

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }


        // POST: api/permissions
        [HttpPost]
        public async Task<IActionResult> PostPermission([FromBody] CreatePermissionRequest createPermission)
        {
            var created = await _permissionService.CreatePermissionAsync(createPermission);

            if (created == null)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/api/permissions/" + created.Id.ToString();

            return Created(location, created);
        }


        // PUT: api/permissions/5
        [HttpPut("{permissionId}")]
        public async Task<IActionResult> PutPermission([FromRoute] Guid permissionId, [FromBody] UpdatePermissionRequest request)
        {
            var updated = await _permissionService.UpdatePermissionAsync(permissionId, request);

            if (updated != null)
                return Ok(updated);

            return NotFound();
        }

        /// <summary>
        /// Assigns permission to user
        /// </summary>
        // PUT: api/permissions/5/3
        [HttpPost("{permissionId}/{userId}")]
        public async Task<IActionResult> PutPermission([FromRoute] Guid permissionId, [FromRoute] Guid userId)
        {
           var created = await _userPermissionService.AsignUserPermissionAsync(permissionId, userId);

            if (!created)
                return BadRequest();

            return NoContent();
        }

        // DELETE: api/permissions/5
        [HttpDelete("{permissionId}")]
        public async Task<IActionResult> DeletePermission(Guid permissionId)
        {
            var deleted = await _permissionService.DeletePermissionAsync(permissionId);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
