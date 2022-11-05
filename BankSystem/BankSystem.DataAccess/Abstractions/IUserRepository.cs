namespace BankSystem.DataAccess.Abstractions;

using BankSystem.Domain.Models;

public interface IUserRepository : IBaseRepository<AppUser>
{
    Task<int> GetUsersQuantity(int Id);

    Task<int> UsersRegisteredthisYear();

    Task<int> UsersRegisteredLastOneYear();

    Task<int> UsersRegisteredLast30Days();
}