namespace MyCredoBanking.Service.Model;

public class CreditCardServiceModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int AccountId { get; set; }
    public string CardNumber { get; set; }
    public DateTime CardExpireDate { get; set; }
    public string Cvv { get; set; }
    public string Pin { get; set; }
}
