using Microsoft.AspNetCore.Mvc;
using PrjManagementApp.Application.DTOs;
using PrjManagementApp.Application.Interfaces;

namespace PrjManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetAllAsync()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetByIdAsync(Guid id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectModel>> CreateAsync(ProjectModel projectModel)
        {
            var createdProject = await _projectService.CreateAsync(projectModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, ProjectModel projectModel)
        {
            await _projectService.UpdateAsync(id, projectModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _projectService.DeleteAsync(id);
            return NoContent(); 
        }
    }
}