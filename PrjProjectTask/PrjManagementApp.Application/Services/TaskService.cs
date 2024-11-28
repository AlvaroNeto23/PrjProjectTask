using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrjManagementApp.Application.DTOs;
using PrjManagementApp.Application.Interfaces;
using PrjManagementApp.Domain.Entities;
using PrjManagementApp.Infrastructure.Data;

namespace PrjManagementApp.Application.Services;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TaskService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskModel>> GetByProjectIdAsync(Guid projectId)
    {
        var tasks = await _context.Tasks
            .Where(t => t.ProjectId == projectId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TaskModel>>(tasks);
    }

    public async Task<TaskModel> GetByIdAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found.");
        }

        return _mapper.Map<TaskModel>(task);
    }

    public async Task<TaskModel> CreateAsync(TaskModel taskModel)
    {
        var task = _mapper.Map<Task>(taskModel);
        task.Id = Guid.NewGuid();
        task.CreatedAt = DateTime.UtcNow;

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return _mapper.Map<TaskModel>(task);
    }

    public async Task UpdateAsync(Guid id, TaskModel taskModel)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
        if (existingTask == null)
        {
            throw new KeyNotFoundException("Task not found.");
        }

        // Atualiza os campos relevantes
        existingTask.Title = taskModel.Title;
        existingTask.Description = taskModel.Description;
        existingTask.IsCompleted = taskModel.IsCompleted;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found.");
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}