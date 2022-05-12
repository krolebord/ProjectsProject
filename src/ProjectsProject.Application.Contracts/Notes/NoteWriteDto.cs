using ProjectsProject.Enums;

namespace ProjectsProject.Notes;

public class NoteWriteDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
}
