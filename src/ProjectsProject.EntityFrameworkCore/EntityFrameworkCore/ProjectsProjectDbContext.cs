using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsProject.DomainModels;
using ProjectsProject.DomainModels.Abstractions;
using ProjectsProject.Extensions;
using Volo.Abp;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users;

namespace ProjectsProject.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ProjectsProjectDbContext :
    AbpDbContext<ProjectsProjectDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public DbSet<Project> Projects { get; set; } = null!;
    
    public DbSet<Note> Notes { get; set; } = null!;
    
    public DbSet<ToDoTask> Tasks { get; set; } = null!;
    
    public DbSet<Label> Labels { get; set; } = null!;

    #region Entities from the modules

    //Identity
    public DbSet<IdentityUser> Users { get; set; } = null!;
    public DbSet<IdentityRole> Roles { get; set; } = null!;
    public DbSet<IdentityClaimType> ClaimTypes { get; set; } = null!;
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; } = null!;
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; } = null!;
    public DbSet<IdentityLinkUser> LinkUsers { get; set; } = null!;

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; } = null!;
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; } = null!;

    #endregion

    protected bool UserEntityFilterEnabled => CurrentUser.IsInRole("admin") ||
                                            DataFilter?.IsEnabled<IUserEntity>() == true;
    
    protected bool SoftDeleteFilterEnabled => DataFilter?.IsEnabled<ISoftDelete>() == true;
    
    public ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

    public ProjectsProjectDbContext(DbContextOptions<ProjectsProjectDbContext> options)
        : base(options)
    {}
    
    protected override bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType)
    {
        if (typeof(IUserEntity).IsAssignableFrom(typeof(TEntity)))
        {
            return true;
        }

        return base.ShouldFilterEntity<TEntity>(entityType);
    }

    protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
    {
        var expression = base.CreateFilterExpression<TEntity>();

        if (typeof(IUserEntity).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> userEntityFilter =
                e => !UserEntityFilterEnabled || EF.Property<Guid>(e, nameof(IUserEntity.UserId)) == CurrentUser.Id;

            Expression<Func<TEntity, bool>> isDeletedFilter =
                e => !SoftDeleteFilterEnabled || !((IUserEntity)e).User!.IsDeleted;

            expression = expression == null 
                ? userEntityFilter 
                : CombineExpressions(expression, userEntityFilter);

            expression = CombineExpressions(expression, isDeletedFilter);
        }

        return expression;
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().ToList())
        {
            if (entry.State == EntityState.Added && entry.Entity is IUserEntity userEntity)
            {
                userEntity.UserId = CurrentUser.GetId();
            }
        }
        
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        builder.Entity<Project>(b => {
            b.ToTable(ProjectsProjectConsts.DbTablePrefix + "Projects");

            b.HasMany(x => x.Labels)
                .WithMany(x => x.Projects);
        });
        
        builder.Entity<Note>(b => {
            b.ToTable(ProjectsProjectConsts.DbTablePrefix + "Notes");

            b.HasMany(x => x.Labels)
                .WithMany(x => x.Notes);
        });
        
        builder.Entity<ToDoTask>(b => {
            b.ToTable(ProjectsProjectConsts.DbTablePrefix + "Tasks");

            b.HasMany(x => x.Labels)
                .WithMany(x => x.Tasks);

            b.HasQueryFilter(task => !task.User!.IsDeleted);
        });
        
        builder.Entity<Label>(b => {
            b.ToTable(ProjectsProjectConsts.DbTablePrefix + "Labels");
        });
    }
}
