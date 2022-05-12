using AutoMapper;
using ProjectsProject.Labels;
using ProjectsProject.Notes;
using ProjectsProject.Projects;
using ProjectsProject.ToDoTasks;

namespace ProjectsProject.Blazor;

public class ProjectsProjectBlazorAutoMapperProfile : Profile
{
    public ProjectsProjectBlazorAutoMapperProfile()
    {
        CreateMap<ProjectDto, ProjectWriteDto>();
        
        CreateMap<ToDoTaskDto, ToDoTaskWriteDto>();
        
        CreateMap<NoteWriteDto, NoteWriteDto>();
        
        CreateMap<LabelWriteDto, LabelDto>();
    }
}
