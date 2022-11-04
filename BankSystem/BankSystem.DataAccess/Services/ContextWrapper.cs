using BankSystem.DataAccess.Abstractions;
using BankSystem.PersistenceDB.Context;

namespace BankSystem.DataAccess.Services;
public class ContextWrapper : IContextWrapper
{
    private readonly IdentityContext _context;

    public ICreditCardRepository cardRepository { get; }

    public IUserAccountRepository userAccountRepository { get; }

    public ITransactionRepository transactionRepository { get; }
    public IUserRepository userRepository { get; }

    public ContextWrapper(IdentityContext context)
    {
        _context = context;
        cardRepository = new CreditCardRepository(_context);
        userAccountRepository = new UserAccountRepository(_context);
        transactionRepository = new TransactionRepository(_context);
        userRepository = new UserRepository(_context);
    }

    

    public void Complete()
    {
         _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
