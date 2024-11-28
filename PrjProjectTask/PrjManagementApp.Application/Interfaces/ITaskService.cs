using PrjManagementApp.Application.DTOs;

namespace PrjManagementApp.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskModel>> GetByProjectIdAsync(Guid projectId);
    Task<TaskModel> GetByIdAsync(Guid id);
    Task<TaskModel> CreateAsync(TaskModel taskModel);
    Task UpdateAsync(Guid id, TaskModel taskModel);
    Task DeleteAsync(Guid id);
}