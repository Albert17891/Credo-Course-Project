namespace MyCredoBanking.Models.Response;

public class CreditCardResponse
{
    public string UserId { get; set; }

    public string CardNumber { get; set; }

    public DateTime CardExpireDate { get; set; }

    public string Cvv { get; set; }

    public string Pin { get; set; }
}