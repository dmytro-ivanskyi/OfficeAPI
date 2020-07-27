using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts.V1.Requests;
using WebAPI.Contracts.V1.Responses;
using WebAPI.Data.Entities;
using WebAPI.Services.Interfaces.ServiceInterfaces;

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
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
        {
            return Ok(await _permissionService.GetPermissions());
        }


        // GET: api/Permissions/5
        [HttpGet("{permissionId}")]
        public async Task<ActionResult<Permission>> GetPermission(Guid permissionId)
        {
            var permission = await _permissionService.GetPermissionById(permissionId);

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }


        // POST: api/Permissions
        [HttpPost]
        public async Task<ActionResult<Permission>> PostPermission([FromBody] CreatePermissionRequest createPermission)
        {
            var permission = new Permission
            {
                Name = createPermission.Name,
                Description = createPermission.Description
            };

            var created = await _permissionService.CreatePermission(permission);

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

            var updated = await _permissionService.UpdatePermission(permission);

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

            var created = await _userPermissionService.CreateUserPermission(userPermission);

            if (!created)
                return BadRequest();

            return NoContent();
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{permissionId}")]
        public async Task<ActionResult<Permission>> DeletePermission(Guid permissionId)
        {
            var deleted = await _permissionService.DeletePermission(permissionId);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
