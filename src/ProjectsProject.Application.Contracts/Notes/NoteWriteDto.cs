using System;
using System.Collections.Generic;
using ProjectsProject.Common;
using ProjectsProject.Enums;

namespace ProjectsProject.Notes;

public class NoteWriteDto : ILabeledWriteDto, IProjectEntityWriteDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
    
    public IEnumerable<Guid> LabelIds { get; set; } = new HashSet<Guid>();
    
    public Guid? ProjectId { get; set; }
}
