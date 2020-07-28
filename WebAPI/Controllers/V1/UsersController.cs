using System;
using System.Threading.Tasks;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts.V1;
using WebAPI.Contracts.V1.Requests;

namespace WebAPI.Controllers.V1
{
    // [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }


        // GET: api/<UsersController>
        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetUsersAsync());
        }


        // GET api/<UsersController>/5
        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<IActionResult> Get(Guid userId)
        {
            return Ok(await _userService.GetUserByIdAsync(userId));
        }


        //// POST api/<UsersController>
        //[HttpPost(ApiRoutes.Users.Create)]
        //public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        //{
        //    var user = new User
        //    {
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        Age = request.Age,
        //        OfficeId = request.OfficeId
        //    };

        //    var created = await _userService.CreateUserAsync(user);

        //    if (!created)
        //        return BadRequest();

        //    var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        //    var location = baseUri + "/[controller]" + user.Id.ToString();

        //    var response = new UserResponse
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Age = user.Age,
        //        OfficeId = user.OfficeId
        //    };

        //    return Created(location, response);
        //}


        //// PUT api/<UsersController>/5
        //[HttpPut(ApiRoutes.Users.Update)]
        //public async Task<IActionResult> Put(Guid userId, [FromBody] UpdateUserRequest request)
        //{
        //    var user = new User
        //    {
        //        Id = userId,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        Age = request.Age,
        //        OfficeId = request.OfficeId
        //    };

        //    var updated = await _userService.UpdateUserAsync(user);

        //    if (updated)
        //        return Ok(user);

        //    return NotFound();
        //}


        // DELETE api/<UsersController>/5
        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var deleted = await _userService.DeleteUserAsync(userId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
