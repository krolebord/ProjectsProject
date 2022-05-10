using ProjectsProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProjectsProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProjectsProjectController : AbpControllerBase
{
    protected ProjectsProjectController()
    {
        LocalizationResource = typeof(ProjectsProjectResource);
    }
}
