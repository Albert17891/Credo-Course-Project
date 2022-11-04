using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Services;

public class TransactionRepository : BaseRepository<Transactions>, ITransactionRepository
{
    private readonly IdentityContext _context;
    public TransactionRepository(IdentityContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetTransactionsOfMounth()
    {
        return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= 30)
            .CountAsync();
    }

    public async Task<int> GetTransactionsOfSixMounth()
    {
        return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= 90)
            .CountAsync();
    }

    public async Task<int> GetTransactionsOfYear()
    {
        return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= 365)
            .CountAsync();
    }

    public async Task<decimal> GetAtmWithdrawTotal()
    {
        return await _context.Transactions.Where(x => x.TransactionType == TransactionType.AtmTransaction)
                                          .Select(x => x.TransferAmount)
                                          .SumAsync();
    }
}
