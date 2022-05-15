using System;
using ProjectsProject.DomainModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.Labels;

public class LabelsAppService
    : CrudAppService<Label, LabelShortDto, Guid, PagedAndSortedResultRequestDto, LabelWriteDto>, ILabelsAppService
{
    public LabelsAppService(IRepository<Label, Guid> repository) : base(repository)
    {}
}
