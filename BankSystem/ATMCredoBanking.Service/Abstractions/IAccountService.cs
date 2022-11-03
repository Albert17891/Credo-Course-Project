namespace AtmCredoBanking.Service.Abstractions;

public interface IAccountService 
{
    Task<bool> CheckCard(string creditCardNumber, string pin);
}
