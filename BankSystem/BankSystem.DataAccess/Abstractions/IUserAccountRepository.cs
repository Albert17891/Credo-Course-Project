using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;
public interface IUserAccountRepository:IBaseRepository<UserAccount>
{
    Task<List<UserAccount>> GetAllUserAccount(string key);
   // Task<UserAccount> GetAccountWithCardId(int Id);
}
