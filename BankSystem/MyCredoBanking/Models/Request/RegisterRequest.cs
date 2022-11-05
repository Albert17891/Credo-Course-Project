namespace MyCredoBanking.Models.Request;

using MyCredoBanking.Infrastracture.Resources;
using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    [Required]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = ErrorMessage.IdNumber)]
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