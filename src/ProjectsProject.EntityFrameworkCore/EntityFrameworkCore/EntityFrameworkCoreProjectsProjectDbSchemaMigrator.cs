using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectsProject.Data;
using Volo.Abp.DependencyInjection;

namespace ProjectsProject.EntityFrameworkCore;

public class EntityFrameworkCoreProjectsProjectDbSchemaMigrator
    : IProjectsProjectDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProjectsProjectDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ProjectsProjectDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProjectsProjectDbContext>()
            .Database
            .MigrateAsync();
    }
}
