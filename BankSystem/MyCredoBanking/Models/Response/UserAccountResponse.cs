namespace MyCredoBanking.Models.Response;

using BankSystem.Domain.Models.Enum;

public class UserAccountResponse
{
    public int Id { get; set; }  
    
    public string Iban { get; set; }

    public decimal Amount { get; set; }

    public Currency Currency { get; set; }
}