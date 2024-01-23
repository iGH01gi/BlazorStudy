using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Data;

public class TestClass
{
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Need TemperatureC")]
    [Range(typeof(int), "-100", "100")]
    public int TemperatureC { get; set; }

    [Required(ErrorMessage = "Need Summary")]
    [StringLength(10, MinimumLength = 2, ErrorMessage = "2~10글자가능")]
    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}