using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProjectsProject.Data;

/* This is used if database provider does't define
 * IProjectsProjectDbSchemaMigrator implementation.
 */
public class NullProjectsProjectDbSchemaMigrator : IProjectsProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
