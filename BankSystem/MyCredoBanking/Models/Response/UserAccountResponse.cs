namespace MyCredoBanking.Models.Response;

public class UserAccountResponse
{
    public int Id { get; set; }
    public string Iban { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
