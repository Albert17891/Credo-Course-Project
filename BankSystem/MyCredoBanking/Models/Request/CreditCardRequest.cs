namespace MyCredoBanking.Models.Request;

using MyCredoBanking.Infrastracture.Resources;
using System.ComponentModel.DataAnnotations;

public class CreditCardRequest
{
    public string UserId { get; set; }
    public int UserAccountId { get; set; }
    [Required]
    [RegularExpression("^[0-9]{16}$", ErrorMessage = ErrorMessage.CardNumber)]
    public string CardNumber { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime CardExpireDate { get; set; }
    [Required]
    [RegularExpression("^[0-9]{3}$", ErrorMessage = ErrorMessage.Cvv)]
    public string Cvv { get; set; }
    [Required]
    [RegularExpression("^[0-9]{4}$", ErrorMessage = ErrorMessage.Pin)]
    public string Pin { get; set; }
}