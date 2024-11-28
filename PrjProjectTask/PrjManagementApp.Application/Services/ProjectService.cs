using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrjManagementApp.Application.DTOs;
using PrjManagementApp.Application.Interfaces;
using PrjManagementApp.Domain.Entities;
using PrjManagementApp.Infrastructure.Data;

namespace PrjManagementApp.Application.Services;

public class ProjectService : IProjectService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProjectService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllAsync()
    {
        var projects = await _context.Projects
            .OrderBy(p => p.CreatedAt)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProjectModel>>(projects);
    }

    public async Task<ProjectModel> GetByIdAsync(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        return _mapper.Map<ProjectModel>(project);
    }

    public async Task<ProjectModel> CreateAsync(ProjectModel projectModel)
    {
        var project = _mapper.Map<Project>(projectModel);
        project.Id = Guid.NewGuid();
        project.CreatedAt = DateTime.UtcNow;

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProjectModel>(project);
    }

    public async Task UpdateAsync(Guid id, ProjectModel projectModel)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject == null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        // Atualiza os campos relevantes
        existingProject.Name = projectModel.Name;
        existingProject.Description = projectModel.Description;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            throw new KeyNotFoundException("Project not found.");
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
    }
}