using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectsProject.Labels;

public interface ILabelsAppService
    : ICrudAppService<LabelDto, Guid, PagedAndSortedResultRequestDto, LabelWriteDto>
{}
