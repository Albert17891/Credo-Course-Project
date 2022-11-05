namespace BankSystem.DataAccess.Services;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using BankSystem.Domain.Models.Extra;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

    public async Task<TransferIncomes> GetAvgIncome()
    {
        return new TransferIncomes()
        {
            EuroTotal = await _context.Transactions.Where(x => x.Currency == Currency.EUR).Select(x => x.TransferFee).AverageAsync(),
            GelTotal = await _context.Transactions.Where(x => x.Currency == Currency.GEL).Select(x => x.TransferFee).AverageAsync(),
            UsdTotal = await _context.Transactions.Where(x => x.Currency == Currency.USD).Select(x => x.TransferFee).AverageAsync()
        };
    }

    public async Task<Dictionary<string, int>> GetChartData()
    {
        var chartData = new Dictionary<string, int>();

        var fromDate = DateTime.Today.AddDays(-30);

        var data = _context.Transactions.Where(x => x.TransactionDate >= fromDate)
            .ForEachAsync(x =>
            {
                var date = x.TransactionDate.ToString("dd/MM");
                if (chartData.ContainsKey(date))
                {
                    chartData[date]++;
                }
                else
                {
                    chartData.Add(x.TransactionDate.ToString("dd/MM"), 1);
                }
            });
        return chartData;
    }

    public async Task<TransferIncomes> GetTotalIncome(int days)
    {
        var fromDate = DateTime.Today.AddDays(-days);

        return new TransferIncomes()
        {
            UsdTotal = await _context.Transactions.Where(x => x.Currency == Currency.USD && x.TransactionDate > fromDate).Select(x => x.TransferFee).SumAsync(),
            GelTotal = await _context.Transactions.Where(x => x.Currency == Currency.GEL && x.TransactionDate > fromDate).Select(x => x.TransferFee).SumAsync(),
            EuroTotal = await _context.Transactions.Where(x => x.Currency == Currency.EUR && x.TransactionDate > fromDate).Select(x => x.TransferFee).SumAsync()
        };
    }

    public async Task<int> GetTransactionsQuantity(int days)
    {
        return await _context.Transactions.Where(x => EF.Functions.DateDiffDay(DateTime.Now, x.TransactionDate) <= days).CountAsync();
    }
}