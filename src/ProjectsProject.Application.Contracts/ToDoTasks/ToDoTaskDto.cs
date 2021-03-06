using System;
using System.Collections.Generic;
using ProjectsProject.Common;
using ProjectsProject.Enums;
using ProjectsProject.Labels;
using ProjectsProject.Projects;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.ToDoTasks;

public class ToDoTaskDto : EntityDto<Guid>, ILabeledDto, ISeverityDto, IProjectEntityDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public bool IsDone { get; set; }
    
    public Severity Severity { get; set; }
    
    public ICollection<LabelShortDto> Labels { get; set; } = new List<LabelShortDto>();
    
    public ProjectShortDto? Project { get; set; }
}
