using System;
using System.Collections.Generic;
using ProjectsProject.DomainModels.Abstractions;
using ProjectsProject.Enums;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace ProjectsProject.DomainModels;

public class Project : AuditedEntity<Guid>, IUserEntity, ILabeled, IHasSeverity
{
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
    
    public Guid UserId { get; set; }
    public IdentityUser? User { get; set; }
    
    public ICollection<Label> Labels { get; set; } = new HashSet<Label>();
}
