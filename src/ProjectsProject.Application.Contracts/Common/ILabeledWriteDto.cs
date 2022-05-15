using System;
using System.Collections.Generic;

namespace ProjectsProject.Common;

public interface ILabeledWriteDto
{
    public IEnumerable<Guid> LabelIds { get; }
}
