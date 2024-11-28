using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrjManagementApp.Domain.Entities;

namespace PrjManagementApp.Domain.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        Task<IEnumerable<Task>> GetTasksByProjectIdAsync(Guid projectId);
    }
}