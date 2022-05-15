using System;
using Volo.Abp.Application.Dtos;

namespace ProjectsProject.Labels;

public class LabelShortDto : EntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
