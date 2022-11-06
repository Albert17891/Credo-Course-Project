namespace BankSystem.DataAccess.Abstractions;

using BankSystem.Domain.Models;

public interface IUserRepository : IBaseRepository<AppUser>
{
    Task<int> GetUsersQuantity(double Id);
}