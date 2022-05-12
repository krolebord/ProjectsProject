using ProjectsProject.Enums;

namespace ProjectsProject.DomainModels.Abstractions;

public interface IHasSeverity
{
    public Severity Severity { get; set; }
}
