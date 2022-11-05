namespace CredoReport.Service.Abstractions;

using BankSystem.Domain.Models.Enum;
using BankSystem.Domain.Models.Extra;

public interface ITransactionStatisticService
{
    Task<int> GetTransactionsQuantityService(int days);

    Task<TransferIncomes> GetTotalIncomeService(int days);

    Task<TransferIncomes> GetAvgIncomeService();

    Task<decimal> GetWithdrawTotalService();
}