using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;

namespace BankSystem.DataAccess.Services;

public class TransactionRepository : BaseRepository<Transactions>, ITransactionRepository
{
    public TransactionRepository(IdentityContext context) : base(context)
    {
    }
}
