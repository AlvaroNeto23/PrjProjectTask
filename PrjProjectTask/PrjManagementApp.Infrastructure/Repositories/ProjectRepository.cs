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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> GetProjectsByNameAsync(string name)
        {
            return await _context.Projects
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }
    }
}