using AutoMapper;
using ProjectsProject.Common;
using ProjectsProject.DomainModels;
using ProjectsProject.DomainModels.Abstractions;
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
        CreateMap<Project, ProjectShortDto>();
        CreateMap<ProjectWriteDto, Project>();
        
        CreateMap<ToDoTask, ToDoTaskDto>();
        CreateMap<ToDoTaskWriteDto, ToDoTask>();
        
        CreateMap<Note, NoteDto>();
        CreateMap<NoteWriteDto, Note>();
        
        CreateMap<Label, LabelShortDto>();
        CreateMap<LabelWriteDto, Label>();

        CreateMap<IProjectEntity, IProjectEntityDto>()
            .IncludeAllDerived();
    }
}
