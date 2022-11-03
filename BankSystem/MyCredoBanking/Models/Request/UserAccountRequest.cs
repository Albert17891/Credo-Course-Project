using MyCredoBanking.Infrastracture.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MyCredoBanking.Models.Request;

public class UserAccountRequest
{
    public int Id { get; set; }

    public string UserId { get; set; }
    
    //[IbanValidation(ErrorMessage ="Iban error")]
    public string Iban { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public Currency Currency { get; set; }
}
