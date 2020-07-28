using System;
using System.Threading.Tasks;
using Data.Abstraction.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts.V1.Requests;

namespace WebAPI.Controllers.V1
{
    [Route("api/userTasks")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public UserTaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/UserTask
        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            return Ok(await _taskService.GetTasksAsync());
        }

        // GET: api/UserTask/5
        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTask(Guid taskId)
        {
            return Ok(await _taskService.GetTaskByIdAsync(taskId));
        }

        //// POST: api/UserTask
        //[HttpPost]
        //public async Task<ActionResult> PostTask(CreateTaskRequest userTask)
        //{
        //    var task = new UserTask
        //    {
        //        Description = userTask.Description,
        //        UserId = userTask.UserId
        //    };

        //    var created = await _taskService.CreateTaskAsync(task);
        //    if (!created)
        //        return BadRequest();

        //    var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        //    var location = baseUri + "/" + task.Id;

        //    var response = new UserTaskResponse
        //    {
        //        Id = task.Id,
        //        Description = task.Description,
        //        UserId = task.UserId
        //    };

        //    return Created(location, response);
        //}

        //// PUT: api/UserTask/5
        //[HttpPut("{taskId}")]
        //public async Task<IActionResult> PutTask(Guid taskId, [FromBody] UpdateTaskRequest request)
        //{
        //    var task = new UserTask
        //    {
        //        Id = taskId,
        //        Description = request.Description,
        //        UserId = request.UserId
        //    };

        //    var updated = await _taskService.UpdateTaskAsync(task);

        //    if (updated)
        //        return Ok(new UserTaskResponse
        //        {
        //            Id = task.Id,
        //            Description = task.Description,
        //            UserId = task.UserId
        //        });

        //    return NotFound();
        //}

        //// DELETE: api/UserTask/5
        //[HttpDelete("{taskId}")]
        //public async Task<ActionResult> DeleteTask(Guid taskId)
        //{
        //    var deleted = await _taskService.DeleteTaskAsync(taskId);

        //    if (deleted)
        //        return NoContent();

        //    return NotFound();
        //}
    }
}
