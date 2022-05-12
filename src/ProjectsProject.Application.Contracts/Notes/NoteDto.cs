using System;
using ProjectsProject.Enums;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.Notes;

public class NoteDto : EntityDto<Guid>
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
}
