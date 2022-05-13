using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using ProjectsProject.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace ProjectsProject.Blazor.Menus;

public class ProjectsProjectMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public ProjectsProjectMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ProjectsProjectResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ProjectsProjectMenus.Projects,
                l["Projects"],
                "/projects",
                icon: Icons.Material.Filled.SpaceDashboard
            )
        );
        
        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                ProjectsProjectMenus.Notes,
                l["Notes"],
                "/notes",
                icon: Icons.Material.Filled.TextSnippet
            )
        );
        
        context.Menu.Items.Insert(
            2,
            new ApplicationMenuItem(
                ProjectsProjectMenus.Tasks,
                l["Tasks"],
                "/tasks",
                icon: Icons.Material.Filled.TaskAlt
            )
        );
        
        context.Menu.Items.Insert(
            3,
            new ApplicationMenuItem(
                ProjectsProjectMenus.Labels,
                l["labels"],
                "/labels",
                icon: Icons.Material.Filled.Label
            )
        );

        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();

        var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

        context.Menu.AddItem(new ApplicationMenuItem(
            "Account.Manage",
            accountStringLocalizer["MyAccount"],
            $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
            icon: "fa fa-cog",
            order: 1000
        ).RequireAuthenticated());

        return Task.CompletedTask;
    }
}
