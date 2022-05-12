using ProjectsProject.Enums;

namespace ProjectsProject.Projects;

public class ProjectWriteDto
{
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
}
