using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
  [StringLength(100, MinimumLength = 3)]
  [Required]
  public string Username { get; set; } = string.Empty;

  [StringLength(100, MinimumLength = 4)]
  [Required]
  public string Password { get; set; } = string.Empty;
}
