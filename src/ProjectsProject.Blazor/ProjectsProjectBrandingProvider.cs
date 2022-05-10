using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProjectsProject.Blazor;

[Dependency(ReplaceServices = true)]
public class ProjectsProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ProjectsProject";
}
