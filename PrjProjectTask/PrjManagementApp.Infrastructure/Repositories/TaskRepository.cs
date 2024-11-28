using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrjManagementApp.Domain.Entities;
using PrjManagementApp.Domain.Repositories;
using PrjManagementApp.Infrastructure.Data;

namespace PrjManagementApp.Infrastructure.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Task>> GetTasksByProjectIdAsync(Guid projectId)
        {
            return await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }
    }
}