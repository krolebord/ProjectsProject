using Volo.Abp.Modularity;

namespace ProjectsProject;

[DependsOn(
    typeof(ProjectsProjectApplicationModule),
    typeof(ProjectsProjectDomainTestModule)
    )]
public class ProjectsProjectApplicationTestModule : AbpModule
{

}
