using MudBlazor.Utilities;

namespace ProjectsProject.Blazor.Extensions;

public static class MudColorExtensions
{
    public static double GetPerceptiveLuminance(this MudColor color)
    {
        return (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
    }

    public static bool IsDark(this MudColor color)
    {
        return color.GetPerceptiveLuminance() < 0.5;
    }
}
