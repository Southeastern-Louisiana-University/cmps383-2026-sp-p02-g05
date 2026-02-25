using System.ComponentModel.DataAnnotations;

namespace Selu383.SP26.Api.Features.User;

public class UserDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Roles { get; set; } = string.Empty;

}