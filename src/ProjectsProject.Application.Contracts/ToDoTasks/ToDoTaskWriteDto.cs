using System;
using System.Collections.Generic;
using ProjectsProject.Common;
using ProjectsProject.Enums;

namespace ProjectsProject.ToDoTasks;

public class ToDoTaskWriteDto : ILabeledWriteDto, IProjectEntityWriteDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public bool IsDone { get; set; }
    
    public Severity Severity { get; set; }

    public IEnumerable<Guid> LabelIds { get; set; } = new HashSet<Guid>();
    
    public Guid? ProjectId { get; set; }
}
