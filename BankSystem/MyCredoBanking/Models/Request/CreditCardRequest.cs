using System.ComponentModel.DataAnnotations;

namespace MyCredoBanking.Models.Request;

public class CreditCardRequest
{
    public string UserId { get; set; }
    public int AccountId { get; set; }
    [Required]
   // [RegularExpression("^[0-9]{16}+$")]
    public string CardNumber { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime CardExpireDate { get; set; }
    [Required]
  //  [RegularExpression("^[0-9]{3}+$")]
    public string Cvv { get; set; }
    [Required]
   // [RegularExpression("^[0-9]{4}+$")]
    public string Pin { get; set; }
}
