using System.ComponentModel.DataAnnotations;

namespace CredoATM.Models;

public class CreditCardLogin
{
    [Required]
    [RegularExpression("^[0-9]{16}$")]
    public string CreditCartNumber { get; set; }
    [Required]
    [RegularExpression("^[0-9]{4}$")]
    public string Pin { get; set; }
}

