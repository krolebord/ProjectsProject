using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectsProject.Notes;

public interface INotesAppService
    : ICrudAppService<NoteDto, Guid, PagedAndSortedResultRequestDto, NoteWriteDto>
{}
