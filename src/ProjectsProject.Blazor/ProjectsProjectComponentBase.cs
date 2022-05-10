using ProjectsProject.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ProjectsProject.Blazor;

public abstract class ProjectsProjectComponentBase : AbpComponentBase
{
    protected ProjectsProjectComponentBase()
    {
        LocalizationResource = typeof(ProjectsProjectResource);
    }
}
