using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectsProject.Labels;

public interface ILabelsAppService
    : ICrudAppService<LabelShortDto, Guid, PagedAndSortedResultRequestDto, LabelWriteDto>
{}
