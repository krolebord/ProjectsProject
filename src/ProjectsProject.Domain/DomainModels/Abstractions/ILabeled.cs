using System.Collections.Generic;

namespace ProjectsProject.DomainModels.Abstractions;

public interface ILabeled
{
    public ICollection<Label> Labels { get; set; }
}
