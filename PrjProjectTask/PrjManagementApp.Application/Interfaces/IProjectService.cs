using PrjManagementApp.Application.DTOs;

namespace PrjManagementApp.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectModel>> GetAllAsync();
    Task<ProjectModel> GetByIdAsync(Guid id);
    Task<ProjectModel> CreateAsync(ProjectModel projectModel);
    Task UpdateAsync(Guid id, ProjectModel projectModel);
    Task DeleteAsync(Guid id);
}