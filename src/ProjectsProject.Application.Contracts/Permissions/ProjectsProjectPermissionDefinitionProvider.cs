using ProjectsProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProjectsProject.Permissions;

public class ProjectsProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {}

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProjectsProjectResource>(name);
    }
}
