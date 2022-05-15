using System;
using System.Collections.Generic;
using ProjectsProject.Common;
using ProjectsProject.Enums;

namespace ProjectsProject.Projects;

public class ProjectWriteDto : ILabeledWriteDto
{
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }

    public IEnumerable<Guid> LabelIds { get; set; } = new HashSet<Guid>();
}
