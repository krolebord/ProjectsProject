using System.Threading.Tasks;

namespace ProjectsProject.Data;

public interface IProjectsProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
