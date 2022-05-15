using System;
using System.Linq;
using System.Threading.Tasks;
using ProjectsProject.DomainModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.Notes;

public class NotesAppService
    : CrudAppService<Note, NoteDto, Guid, PagedAndSortedResultRequestDto, NoteWriteDto>, INotesAppService
{
    private readonly IRepository<Label, Guid> _labelsRepository;
    
    public NotesAppService(IRepository<Note, Guid> repository, IRepository<Label, Guid> labelsRepository) : base(repository)
    {
        _labelsRepository = labelsRepository;
    }
    
    protected override async Task<Note> GetEntityByIdAsync(Guid id)
    {
        var query = await Repository.WithDetailsAsync(x => x.Labels, x => x.Project);
        return await AsyncExecuter.FirstAsync(query, x => x.Id == id);
    }

    public override async Task<NoteDto> CreateAsync(NoteWriteDto input)
    {
        await CheckCreatePolicyAsync();

        var entity = await MapToEntityAsync(input);

        TryToSetTenantId(entity);

        entity.Labels = await _labelsRepository.GetListAsync(x => input.LabelIds.Contains(x.Id));

        await Repository.InsertAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    public override async Task<NoteDto> UpdateAsync(Guid id, NoteWriteDto input)
    {
        await CheckUpdatePolicyAsync();

        var entity = await GetEntityByIdAsync(id);
        await Repository.EnsureCollectionLoadedAsync(entity, x => x.Labels);
        
        await MapToEntityAsync(input, entity);
        
        entity.Labels = await _labelsRepository.GetListAsync(x => input.LabelIds.Contains(x.Id));
        
        await Repository.UpdateAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    protected override async Task<IQueryable<Note>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        return await ReadOnlyRepository.WithDetailsAsync(x => x.Labels, x => x.Project);
    }
}
