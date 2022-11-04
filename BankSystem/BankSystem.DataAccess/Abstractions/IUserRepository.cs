using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;
public interface IUserRepository:IBaseRepository<AppUser>
{
    Task<int> GetUsersOfThisYear();
    Task<int> GetUsersOfOneYear();
    Task<int> GetUsersOfOneMonth();
}
