using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectsProject.Projects;

public interface IProjectsAppService
    : ICrudAppService<ProjectDto, Guid, PagedAndSortedResultRequestDto, ProjectWriteDto>
{
    Task<IEnumerable<ProjectShortDto>> GetShortsList();
}
