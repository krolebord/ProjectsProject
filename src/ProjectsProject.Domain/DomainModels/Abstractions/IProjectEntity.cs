using System;

namespace ProjectsProject.DomainModels.Abstractions;

public interface IProjectEntity
{
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }
}
