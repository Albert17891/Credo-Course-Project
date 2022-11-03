using BankSystem.Domain.Models.Enum;

namespace BankSystem.Domain.Models;

public class UserAccount 
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public AppUser User { get; set; }

    public string Iban { get; set; }

    public decimal Amount { get; set; }

    public Currency Currency { get; set; }

    public IList<CreditCard> CreditCards { get; set; }
}
