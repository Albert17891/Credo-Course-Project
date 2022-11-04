using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;
public interface IUserRepository : IBaseRepository<AppUser>
{
    Task<int> GetUsersQuantity(int Id);

}
