using System.ComponentModel.DataAnnotations;

namespace MyCredoBanking.Models.Request;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
