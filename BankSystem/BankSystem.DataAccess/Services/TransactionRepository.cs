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

    public async Task<decimal> GetAtmWithdrawTotal()
    {
        return await _context.Transactions.Where(x => x.TransactionType == TransactionType.AtmTransaction)
                                          .Select(x => x.TransferAmount)
                                          .SumAsync();
    }

    public async Task<int> GetTransactionsQuantity(int Id)
    {
        switch (Id)
        {
            case 30:
                {
                    //For Month
                    return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= 30)
                                                      .CountAsync();
                    break;
                }
            case 180:
                {
                    //For 6 Month
                    return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= 180)
                                                      .CountAsync();
                    break;
                }
            default:
                {
                    //For Year
                    return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= 365)
                                                      .CountAsync();
                    break;
                }
        }
    }
}
