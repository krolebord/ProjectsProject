using System;
using System.Linq;
using System.Threading.Tasks;
using ProjectsProject.DomainModels;
using ProjectsProject.Projects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.ToDoTasks;

public class ToDoTasksAppService
    : CrudAppService<ToDoTask, ToDoTaskDto, Guid, PagedAndSortedResultRequestDto, ToDoTaskWriteDto>, IToDoTasksAppService
{
    private readonly IRepository<Label, Guid> _labelsRepository;
    
    public ToDoTasksAppService(IRepository<ToDoTask, Guid> repository, IRepository<Label, Guid> labelsRepository) : base(repository)
    {
        _labelsRepository = labelsRepository;
    }
    
    protected override async Task<ToDoTask> GetEntityByIdAsync(Guid id)
    {
        var query = await Repository.WithDetailsAsync(x => x.Labels, x => x.Project);
        return await AsyncExecuter.FirstAsync(query, x => x.Id == id);
    }

    public override async Task<ToDoTaskDto> CreateAsync(ToDoTaskWriteDto input)
    {
        await CheckCreatePolicyAsync();

        var entity = await MapToEntityAsync(input);

        TryToSetTenantId(entity);

        entity.Labels = await _labelsRepository.GetListAsync(x => input.LabelIds.Contains(x.Id));

        await Repository.InsertAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    public override async Task<ToDoTaskDto> UpdateAsync(Guid id, ToDoTaskWriteDto input)
    {
        await CheckUpdatePolicyAsync();

        var entity = await GetEntityByIdAsync(id);
        await Repository.EnsureCollectionLoadedAsync(entity, x => x.Labels);
        
        await MapToEntityAsync(input, entity);
        
        entity.Labels = await _labelsRepository.GetListAsync(x => input.LabelIds.Contains(x.Id));
        
        await Repository.UpdateAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    protected override async Task<IQueryable<ToDoTask>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        return await ReadOnlyRepository.WithDetailsAsync(x => x.Labels, x => x.Project);
    }
}
