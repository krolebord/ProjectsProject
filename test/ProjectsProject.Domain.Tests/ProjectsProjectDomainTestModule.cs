using ProjectsProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ProjectsProject;

[DependsOn(
    typeof(ProjectsProjectEntityFrameworkCoreTestModule)
    )]
public class ProjectsProjectDomainTestModule : AbpModule
{

}
