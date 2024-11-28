using AutoMapper;
using PrjManagementApp.Application.DTOs;
using PrjManagementApp.Domain.Entities;

namespace PrjManagementApp.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Task, TaskModel>().ReverseMap();
        CreateMap<Project, ProjectModel>().ReverseMap();
    }
}