using System;
using System.Collections.Generic;
using ProjectsProject.DomainModels.Abstractions;
using ProjectsProject.Enums;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace ProjectsProject.DomainModels;

public class Note : AuditedEntity<Guid>, IUserEntity, ILabeled, IHasSeverity
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public Severity Severity { get; set; }
    
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }
    
    public Guid UserId { get; set; }
    public IdentityUser? User { get; set; }

    public ICollection<Label> Labels { get; set; } = new HashSet<Label>();
}
