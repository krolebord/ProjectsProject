using System.Threading.Tasks;
using ProjectsProject.DomainModels.Abstractions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace ProjectsProject.Abstract;

public class CrudUserEntityAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput>
    : CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput>
    where TEntity : class, IUserEntity, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    public CrudUserEntityAppService(IRepository<TEntity, TKey> repository) : base(repository)
    {}
}
