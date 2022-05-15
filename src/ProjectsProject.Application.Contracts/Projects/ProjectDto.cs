using System;
using System.Collections.Generic;
using ProjectsProject.Common;
using ProjectsProject.Enums;
using ProjectsProject.Labels;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.Projects;

public class ProjectDto : EntityDto<Guid>, ISeverityDto, ILabeledDto
{
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }

    public ICollection<LabelShortDto> Labels { get; set; } = new HashSet<LabelShortDto>();
}
