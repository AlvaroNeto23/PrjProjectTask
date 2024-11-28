using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrjManagementApp.Domain.Entities;

namespace PrjManagementApp.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
    }
}