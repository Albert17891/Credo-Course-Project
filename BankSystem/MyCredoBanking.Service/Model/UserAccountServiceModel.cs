using BankSystem.Domain.Models.Enum;

namespace MyCredoBanking.Service.Model;

public class UserAccountServiceModel
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string Iban { get; set; }
    
    public decimal Amount { get; set; }
    
    public Currency Currency { get; set; }
}
