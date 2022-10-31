using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Servcices;
public class UserAccountRepository : BaseRepository<UserAccount>, IUserAccountRepository
{
    private readonly BankingSystemContext _context;
    public UserAccountRepository(BankingSystemContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<UserAccount>> GetAllUserAccount(string key)
    {
       return await Table.Where(x => x.UserId == key).ToListAsync();
    }
}
