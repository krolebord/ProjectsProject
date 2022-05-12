using System;
using ProjectsProject.Enums;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.ToDoTasks;

public class ToDoTaskDto : EntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public bool IsDone { get; set; }
    
    public Severity Severity { get; set; }
}
