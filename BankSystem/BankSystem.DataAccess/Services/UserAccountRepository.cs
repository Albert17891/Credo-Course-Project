using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;

namespace BankSystem.DataAccess.Servcices;
public class UserAccountRepository : BaseRepository<UserAccount>, IUserAccountRepository
{
    private readonly BankingSystemContext _context;
    public UserAccountRepository(BankingSystemContext context) : base(context)
    {
        _context = context;
    }
}
