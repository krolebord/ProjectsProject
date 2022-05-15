using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectsProject.DomainModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.Projects;

public class ProjectsAppService
    : CrudAppService<Project, ProjectDto, Guid, PagedAndSortedResultRequestDto, ProjectWriteDto>, IProjectsAppService
{
    private readonly IRepository<Label, Guid> _labelsRepository;

    public ProjectsAppService(IRepository<Project, Guid> repository, IRepository<Label, Guid> labelsRepository) : base(repository)
    {
        _labelsRepository = labelsRepository;
    }

    protected override async Task<Project> GetEntityByIdAsync(Guid id)
    {
        var query = await Repository.WithDetailsAsync(x => x.Labels);
        return await AsyncExecuter.FirstAsync(query, x => x.Id == id);
    }

    public override async Task<ProjectDto> CreateAsync(ProjectWriteDto input)
    {
        await CheckCreatePolicyAsync();

        var entity = await MapToEntityAsync(input);

        TryToSetTenantId(entity);

        entity.Labels = await _labelsRepository.GetListAsync(x => input.LabelIds.Contains(x.Id));

        await Repository.InsertAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    public override async Task<ProjectDto> UpdateAsync(Guid id, ProjectWriteDto input)
    {
        await CheckUpdatePolicyAsync();

        var entity = await GetEntityByIdAsync(id);
        await Repository.EnsureCollectionLoadedAsync(entity, x => x.Labels);
        
        await MapToEntityAsync(input, entity);
        
        entity.Labels = await _labelsRepository.GetListAsync(x => input.LabelIds.Contains(x.Id));
        
        await Repository.UpdateAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }
    
    public async Task<IEnumerable<ProjectShortDto>> GetShortsList()
    {
        var projects = await Repository.GetListAsync();
        return ObjectMapper.Map<ICollection<Project>, ICollection<ProjectShortDto>>(projects);
    }

    protected override async Task<IQueryable<Project>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        return await ReadOnlyRepository.WithDetailsAsync(x => x.Labels);
    }
}
