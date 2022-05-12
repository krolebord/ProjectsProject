using System;
using ProjectsProject.Enums;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.Projects;

public class ProjectDto : EntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
}
