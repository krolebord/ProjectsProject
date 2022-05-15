using System.Linq;
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
        CreateMap<ProjectDto, ProjectWriteDto>()
            .ForMember(x => x.LabelIds, opt => opt.MapFrom(x => x.Labels.Select(label => label.Id)));
        
        CreateMap<ToDoTaskDto, ToDoTaskWriteDto>()
            .ForMember(x => x.LabelIds, opt => opt.MapFrom(x => x.Labels.Select(label => label.Id)));
        
        CreateMap<NoteDto, NoteWriteDto>()
            .ForMember(x => x.LabelIds, opt => opt.MapFrom(x => x.Labels.Select(label => label.Id)));

        CreateMap<LabelShortDto, LabelWriteDto>();
    }
}
