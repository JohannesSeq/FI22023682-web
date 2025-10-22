namespace MVC.Models;

using System.ComponentModel.DataAnnotations;

public class TheModel
{
    [Required(ErrorMessage = "No se admiten frases vacias.")]
       [StringLength(25, MinimumLength = 5, ErrorMessage = "Se requieren frases de 5 a 25 letras!!")]
    public string? Phrase { get; set; } //Se agrego el ? para resolver el error CS8618 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings

    public Dictionary<char, int> Counts { get; set; } = [];

    public string? Lower { get; set; } //Se agrego el ? para resolver el error CS8618 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings

    public string? Upper { get; set; } //Se agrego el ? para resolver el error CS8618 https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings
}
