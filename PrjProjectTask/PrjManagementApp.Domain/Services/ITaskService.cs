using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrjManagementApp.Domain.Entities;

namespace PrjManagementApp.Domain.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> GetTaskByIdAsync(Guid id);
        Task<IEnumerable<Task>> GetTasksByProjectIdAsync(Guid projectId);
        Task AddTaskAsync(Task task);
        Task UpdateTaskAsync(Task task);
        Task DeleteTaskAsync(Guid id);
    }
}