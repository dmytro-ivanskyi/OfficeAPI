using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ServiceInterfaces;
using WebAPI.Contracts.V1;

namespace WebAPI.Controllers.V1
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }


        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetUsersAsync());
        }


        // GET api/user/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            return Ok(await _userService.GetUserByIdAsync(userId));
        }


        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            var created = await _userService.CreateUserAsync(request);

            if (created == null)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/api/user/" + created.Id.ToString();

            return Created(location, created);
        }


        // PUT api/user/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UpdateUserRequest request)
        {

            var updatedUser = await _userService.UpdateUserAsync(userId, request);

            if (updatedUser != null)
                return Ok(updatedUser);

            return NotFound();
        }


        // DELETE api/user/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var deleted = await _userService.DeleteUserAsync(userId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
