namespace MyCredoBanking.Service.Model;

public class UserAccountServiceModel
{
    public string UserId { get; set; }

    public string Iban { get; set; }
    
    public decimal Amount { get; set; }
    
    public string Currency { get; set; }
}
