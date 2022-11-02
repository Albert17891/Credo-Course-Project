using Microsoft.Build.Framework;

namespace MyCredoBanking.Models.Transaction;

public class HowMuchMoney
{
    [Required]
    public decimal Amount { get; set; }
}
