using AutoMapper;
using ProjectsProject.DomainModels;
using ProjectsProject.Labels;
using ProjectsProject.Notes;
using ProjectsProject.Projects;
using ProjectsProject.ToDoTasks;

namespace ProjectsProject;

public class ProjectsProjectApplicationAutoMapperProfile : Profile
{
    public ProjectsProjectApplicationAutoMapperProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectWriteDto, Project>();
        
        CreateMap<ToDoTask, ToDoTaskDto>();
        CreateMap<ToDoTaskWriteDto, ToDoTask>();
        
        CreateMap<Note, NoteDto>();
        CreateMap<NoteWriteDto, Note>();
        
        CreateMap<Label, LabelShortDto>();
        CreateMap<LabelWriteDto, Label>();
    }
}
