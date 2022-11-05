namespace BankSystem.DataAccess.Abstractions;


using BankSystem.Domain.Models;

public interface IUserAccountRepository:IBaseRepository<UserAccount>
{
    Task<IList<UserAccount>> GetAllUserAccount(string key);

    Task<IList<UserAccount>> GetAllOtherAccount(string key, int firstAccount);
}