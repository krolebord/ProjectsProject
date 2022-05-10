using ProjectsProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ProjectsProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProjectsProjectEntityFrameworkCoreModule),
    typeof(ProjectsProjectApplicationContractsModule)
    )]
public class ProjectsProjectDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
