using System.Collections.Generic;
using ProjectsProject.Labels;

namespace ProjectsProject.Common;

public interface ILabeledDto
{
    ICollection<LabelShortDto> Labels { get; }
}
