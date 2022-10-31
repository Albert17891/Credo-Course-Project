namespace MyCredoBanking.Models.Request;

public class UserAccountRequest
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int CardId { get; set; }
    public string Iban { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
