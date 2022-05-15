using System;
using System.Collections.Generic;
using ProjectsProject.Common;
using ProjectsProject.Enums;
using ProjectsProject.Labels;
using ProjectsProject.Projects;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.Notes;

public class NoteDto : EntityDto<Guid>, ILabeledDto, ISeverityDto, IProjectEntityDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }

    public ProjectShortDto? Project { get; set; }

    public ICollection<LabelShortDto> Labels { get; set; } = new List<LabelShortDto>();
}
