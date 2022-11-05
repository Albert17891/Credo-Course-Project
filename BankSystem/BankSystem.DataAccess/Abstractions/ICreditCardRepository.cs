namespace BankSystem.DataAccess.Abstractions;

using BankSystem.Domain.Models;

public interface ICreditCardRepository :IBaseRepository<CreditCard>
{
    Task<List<CreditCard>> GetAllCreditCard(string key);
    Task<bool> CheckReplaceableCards(int Id);
    Task<bool> CheckExpiredCards(int Id);
}