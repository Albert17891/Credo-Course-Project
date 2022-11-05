namespace BankSystem.DataAccess.Services;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

public class UserAccountRepository : BaseRepository<UserAccount>, IUserAccountRepository
{
    private readonly IdentityContext _context;
    public UserAccountRepository(IdentityContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<UserAccount>> GetAllOtherAccount(string key, int firstAccount)
    {
        return await Table.Where(x => x.UserId == key && x.Id != firstAccount).ToListAsync();
    }

    public async Task<IList<UserAccount>> GetAllUserAccount(string key)
    {
        return await Table.Where(x => x.UserId == key).ToListAsync();
    }
}