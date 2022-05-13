using ProjectsProject.Localization;
using Volo.Abp.Application.Services;

namespace ProjectsProject;

/* Inherit your application services from this class.
 */
public abstract class ProjectsProjectAppService : ApplicationService
{
    protected ProjectsProjectAppService()
    {
        LocalizationResource = typeof(ProjectsProjectResource);
    }
}
