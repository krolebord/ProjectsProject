using System.ComponentModel.DataAnnotations;

namespace ProjectsProject.Labels;

public class LabelWriteDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [RegularExpression("#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})", ErrorMessage = "Invalid color")]
    public string Color { get; set; } = string.Empty;

    [MinLength(5)]
    public string? Description { get; set; }
}
