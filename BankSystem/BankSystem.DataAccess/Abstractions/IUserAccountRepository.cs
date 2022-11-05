namespace BankSystem.DataAccess.Abstractions;


using BankSystem.Domain.Models;

public interface IUserAccountRepository:IBaseRepository<UserAccount>
{
    Task<List<UserAccount>> GetAllUserAccount(string key);
}