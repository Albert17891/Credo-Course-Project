namespace CredoReport.Service.Service;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models.Extra;
using CredoReport.Models.TransactionStastistic;
using CredoReport.Service.Abstractions;
using System.Collections.Generic;

public class TransactionStatisticService : ITransactionStatisticService
{
    private readonly IContextWrapper _contextWrapper;

    public TransactionStatisticService(IContextWrapper contextWrapper)
    {
        _contextWrapper = contextWrapper;
    }

    public async Task<int> GetTransactionsQuantityService(int days)
    {
        return await _contextWrapper.transactionRepository.GetTransactionsQuantity(days);
    }

    public async Task<TransferIncomes> GetTotalIncomeService(int days)
    {
        return await _contextWrapper.transactionRepository.GetTotalIncome(days);
    }

    public async Task<TransferIncomes> GetAvgIncomeService()
    {
        return await _contextWrapper.transactionRepository.GetAvgIncome();
    }

    public async Task<decimal> GetWithdrawTotalService()
    {
        return await _contextWrapper.transactionRepository.GetAtmWithdrawTotal();
    }

    public async Task<ChartJsServieModel> GetChartDataService()
    {
        var data= await _contextWrapper.transactionRepository.GetChartData();

        var chart = ChartService.GetChart(data);

        return chart;
    }
}