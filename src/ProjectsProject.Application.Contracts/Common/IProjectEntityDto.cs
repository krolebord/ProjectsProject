using ProjectsProject.Projects;

namespace ProjectsProject.Common;

public interface IProjectEntityDto
{
    public ProjectShortDto? Project { get; set; }
}
