using System;
using System.Linq;
using AutoMapper;
using ProjectsProject.Common;
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

        CreateMap<NoteDto, NoteWriteDto>();

        CreateMap<LabelShortDto, LabelWriteDto>();
        
        CreateMap<ILabeledDto, ILabeledWriteDto>()
            .ForMember(x => x.LabelIds, opt => opt.MapFrom(x => x.Labels.Select(label => label.Id)))
            .IncludeAllDerived();
        
        CreateMap<IProjectEntityDto, IProjectEntityWriteDto>()
            .ForMember(x => x.ProjectId, opt => opt.MapFrom(x => x.Project == null ? null : new Guid?(x.Project.Id)))
            .IncludeAllDerived();
    }
}
