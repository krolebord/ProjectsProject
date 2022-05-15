using System;
using ProjectsProject.Enums;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.Projects;

public class ProjectShortDto : EntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;

    public Severity Severity { get; set; }
}
