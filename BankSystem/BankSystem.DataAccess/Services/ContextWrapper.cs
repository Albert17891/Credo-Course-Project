using BankSystem.DataAccess.Abstractions;
using BankSystem.PersistenceDB.Context;

namespace BankSystem.DataAccess.Servcices;
public class ContextWrapper : IContextWrapper
{
    private readonly BankingSystemContext _context;
    public ICreditCardRepository cardRepository { get; }
    public IUserAccountRepository userAccountRepository { get; }

    public ContextWrapper(BankingSystemContext context)
    {
        _context = context;
        cardRepository = new CreditCardRepository(_context);
        userAccountRepository = new UserAccountRepository(_context);
    }

    

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
