using System;
using System.Threading.Tasks;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts.V1.Requests;
using WebAPI.Contracts.V1.Responses;

namespace WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
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


        // GET: api/Permissions
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            return Ok(await _permissionService.GetPermissionsAsync());
        }


        // GET: api/Permissions/5
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


        // POST: api/Permissions
        [HttpPost]
        public async Task<IActionResult> PostPermission([FromBody] CreatePermissionRequest createPermission)
        {
            var permission = new Permission
            {
                Name = createPermission.Name,
                Description = createPermission.Description
            };

            var created = await _permissionService.CreatePermissionAsync(permission);

            if (!created)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/[controller]" + permission.Id.ToString();

            var response = new PermissionResponse
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            };

            return Created(location, response);
        }


        // PUT: api/Permissions/5
        [HttpPut("{permissionId}")]
        public async Task<IActionResult> PutPermission([FromRoute] Guid permissionId, [FromBody] UpdatePermissionRequest request)
        {
            var permission = new Permission
            {
                Id = permissionId,
                Name = request.Name,
                Description = request.Description
            };

            var updated = await _permissionService.UpdatePermissionAsync(permission);

            if (updated)
                return Ok(permission);

            return NotFound();
        }

        /// <summary>
        /// Assigns permission to user
        /// </summary>
        // PUT: api/Permissions/5/3
        [HttpPost("{permissionId}/{userId}")]
        public async Task<IActionResult> PutPermission([FromRoute] Guid permissionId, [FromRoute] Guid userId)
        {
            var userPermission = new UserPermission
            {
                UserId = userId,
                PermissionId = permissionId
            };

            var created = await _userPermissionService.CreateUserPermissionAsync(userPermission);

            if (!created)
                return BadRequest();

            return NoContent();
        }

        // DELETE: api/Permissions/5
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
