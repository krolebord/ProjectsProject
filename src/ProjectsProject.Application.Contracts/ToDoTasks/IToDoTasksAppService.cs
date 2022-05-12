using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectsProject.ToDoTasks;

public interface IToDoTasksAppService
    : ICrudAppService<ToDoTaskDto, Guid, PagedAndSortedResultRequestDto, ToDoTaskWriteDto>
{}
