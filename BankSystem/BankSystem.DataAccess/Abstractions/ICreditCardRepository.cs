using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;
public interface ICreditCardRepository :IBaseRepository<CreditCard>
{
    Task<List<CreditCard>> GetAllCreditCard(string key);
    Task<List<CreditCard>> GetReplaceableCards();
    Task<List<CreditCard>> GetExpiredCards();
}
