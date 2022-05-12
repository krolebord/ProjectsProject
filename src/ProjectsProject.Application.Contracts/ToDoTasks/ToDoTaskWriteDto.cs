using ProjectsProject.Enums;

namespace ProjectsProject.ToDoTasks;

public class ToDoTaskWriteDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public bool IsDone { get; set; }
    
    public Severity Severity { get; set; }
}
