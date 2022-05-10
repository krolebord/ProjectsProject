using ProjectsProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProjectsProject.Permissions;

public class ProjectsProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProjectsProjectPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProjectsProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProjectsProjectResource>(name);
    }
}
