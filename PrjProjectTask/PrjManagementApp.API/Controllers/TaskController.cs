using Microsoft.AspNetCore.Mvc;
using PrjManagementApp.Application.DTOs;
using PrjManagementApp.Application.Interfaces;

namespace PrjManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetByProjectIdAsync(Guid projectId)
        {
            var tasks = await _taskService.GetByProjectIdAsync(projectId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetByIdAsync(Guid id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateAsync(TaskModel taskModel)
        {
            var createdTask = await _taskService.CreateAsync(taskModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, TaskModel taskModel)
        {
            await _taskService.UpdateAsync(id, taskModel);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _taskService.DeleteAsync(id);
            return NoContent(); 
        }
    }
}