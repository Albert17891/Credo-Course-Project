using CredoATM.Infrastracture.Resources;
using System.ComponentModel.DataAnnotations;

namespace CredoATM.Models;

public class Withdraw
{
    [Required]
    [RegularExpression("^[1-9][0-9]*$", ErrorMessage = ErrorMessage.Amount)]
    public decimal WithdrawAmount { get; set; }
}