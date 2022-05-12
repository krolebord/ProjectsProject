using System;
using ProjectsProject.DomainModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.Projects;

public class ProjectsAppService
    : CrudAppService<Project, ProjectDto, Guid, PagedAndSortedResultRequestDto, ProjectWriteDto>, IProjectsAppService
{
    public ProjectsAppService(IRepository<Project, Guid> repository) : base(repository)
    {}
}
