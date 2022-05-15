using System;
using ProjectsProject.Enums;

namespace ProjectsProject.Blazor.Extensions;

public static class SeverityExtensions
{
    public static MudBlazor.Severity ToMudSeverity(this Severity severity)
    {
        return severity switch
        {

            Severity.Default => MudBlazor.Severity.Normal,
            Severity.Info => MudBlazor.Severity.Info,
            Severity.Success => MudBlazor.Severity.Success,
            Severity.Warning => MudBlazor.Severity.Warning,
            Severity.Error => MudBlazor.Severity.Error,
            _ => throw new ArgumentOutOfRangeException(nameof(severity), severity, null)
        };
    }
}
