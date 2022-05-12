using System;
using ProjectsProject.DomainModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.Notes;

public class NotesAppService
    : CrudAppService<Note, NoteDto, Guid, PagedAndSortedResultRequestDto, NoteWriteDto>, INotesAppService
{
    public NotesAppService(IRepository<Note, Guid> repository) : base(repository)
    {}
}
