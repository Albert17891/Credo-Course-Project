using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;
public interface ICreditCardRepository :IBaseRepository<CreditCard>
{
    Task<List<CreditCard>> GetAllCreditCard(string key);
    Task<bool> CheckReplaceableCards(int Id);
    Task<bool> CheckExpiredCards(int Id);
}
