using BankSystem.Domain.Models.Enum;

namespace MyCredoBanking.Models.Response;

public class UserAccountResponse
{
    public int Id { get; set; }   
    public string Iban { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
}
