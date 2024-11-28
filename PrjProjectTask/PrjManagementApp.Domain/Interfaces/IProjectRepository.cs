using System.Collections.Generic;
using System.Threading.Tasks;
using PrjManagementApp.Domain.Entities;

namespace PrjManagementApp.Domain.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {   
        Task<IEnumerable<Project>> GetProjectsByNameAsync(string name);
    }
}