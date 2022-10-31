namespace MyCredoBanking.Models.Response;

public class CreditCardResponse
{
    public string CardNumber { get; set; }
    public DateTime CardExpireDate { get; set; }
    public int Cvv { get; set; }
    public int Pin { get; set; }
}
