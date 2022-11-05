namespace BankSystem.Domain.Models;

public class CreditCard
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public AppUser User { get; set; }

    public int UserAccountId { get; set; }

    public UserAccount UserAccount { get; set; }

    public string CardNumber { get; set; }

    public DateTime CardExpireDate { get; set; }

    public string Cvv { get; set; }

    public string Pin { get; set; }
}