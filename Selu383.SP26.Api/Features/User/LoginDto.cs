using System.ComponentModel.DataAnnotations;

namespace Selu383.SP26.Api.Features.Locations;

public class LoginDto
{
    public string Username { get; set; }
 
    [Required]
    [MaxLength(120)]
    public string Password { get; set; } = string.Empty;

   
}