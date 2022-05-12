using System;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace ProjectsProject.DomainModels.Abstractions;

public interface IUserEntity
{
    public Guid UserId { get; set; }
    public IdentityUser? User { get; set; }
}
