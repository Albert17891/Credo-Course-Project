namespace MyCredoBanking.Models.Request;

public class CreditCardRequest
{
    public string UserId { get; set; }
    public int AccountId { get; set; }
    public string CardNumber { get; set; }
    public DateTime CardExpireDate { get; set; }
    public int Cvv { get; set; }
    public int Pin { get; set; }
}
