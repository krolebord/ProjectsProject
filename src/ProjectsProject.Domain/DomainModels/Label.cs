using System;
using System.Collections.Generic;
using ProjectsProject.DomainModels.Abstractions;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace ProjectsProject.DomainModels;

public class Label : CreationAuditedEntity<Guid>, IUserEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Color { get; set; }

    public Guid UserId { get; set; }
    public IdentityUser? User { get; set; }
    
    public ICollection<Project> Projects { get; set; } = new HashSet<Project>();

    public ICollection<ToDoTask> Tasks { get; set; } = new HashSet<ToDoTask>();

    public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
}
