namespace BankSystem.Domain.Models;
public class CreditCard
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AccountId { get; set; }
    public string CardNumber { get; set; }
    public DateTime CardExpireDate { get; set; }
    public int Cvv { get; set; }
    public int Pin { get; set; }
}
