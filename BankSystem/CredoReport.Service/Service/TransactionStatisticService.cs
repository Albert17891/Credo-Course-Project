namespace CredoReport.Service.Service;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models.Enum;
using BankSystem.Domain.Models.Extra;
using CredoReport.Service.Abstractions;

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
}