using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.RequestModels;
using Service.Abstraction.ServiceInterfaces;

namespace WebAPI.Controllers.V1
{
    [Route("api/userTask")]
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

        // POST: api/UserTask
        [HttpPost]
        public async Task<ActionResult> PostTask(CreateTaskRequest userTask)
        {
            var created = await _taskService.CreateTaskAsync(userTask);

            if (created == null)
                return BadRequest();

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUri + "/api/userTask/" + created.Id;

            return Created(location, created);
        }

        // PUT: api/UserTask/5
        [HttpPut("{taskId}")]
        public async Task<IActionResult> PutTask(Guid taskId, [FromBody] UpdateTaskRequest request)
        {

            var updatedTask = await _taskService.UpdateTaskAsync(taskId, request);

            if (updatedTask != null)
                return Ok(updatedTask);

            return NotFound();
        }

        // DELETE: api/UserTask/5
        [HttpDelete("{taskId}")]
        public async Task<ActionResult> DeleteTask(Guid taskId)
        {
            var deleted = await _taskService.DeleteTaskAsync(taskId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
