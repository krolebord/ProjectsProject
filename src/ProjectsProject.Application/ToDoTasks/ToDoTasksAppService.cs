using System;
using ProjectsProject.DomainModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.ToDoTasks;

public class ToDoTasksAppService
    : CrudAppService<ToDoTask, ToDoTaskDto, Guid, PagedAndSortedResultRequestDto, ToDoTaskWriteDto>, IToDoTasksAppService
{
    public ToDoTasksAppService(IRepository<ToDoTask, Guid> repository) : base(repository)
    {}
}
