namespace CredoReport.Service.Abstractions;

using BankSystem.Domain.Models.Extra;
using CredoReport.Models.TransactionStastistic;

public interface ITransactionStatisticService
{
    Task<int> GetTransactionsQuantityService(int days);

    Task<TransferIncomes> GetTotalIncomeService(int days);

    Task<TransferIncomes> GetAvgIncomeService();

    Task<decimal> GetWithdrawTotalService();

    Task<ChartJsServieModel> GetChartDataService();
}