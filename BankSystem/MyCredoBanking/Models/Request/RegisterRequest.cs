using System.ComponentModel.DataAnnotations;

namespace MyCredoBanking.Models.Request;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    [Required]    
    [RegularExpression("^[0-9]{11}+$")]
    public string IdNumber { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
