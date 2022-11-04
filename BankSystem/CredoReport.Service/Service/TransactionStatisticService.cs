using BankSystem.DataAccess.Abstractions;
using CredoReport.Service.Abstractions;

namespace CredoReport.Service.Service;
public class TransactionStatisticService : ITransactionStatisticService
{
    private readonly IContextWrapper _contextWrapper;

    public TransactionStatisticService(IContextWrapper contextWrapper)
    {
        _contextWrapper = contextWrapper;
    }
    public async Task<decimal> GetAtmWithdrawTotalService()
    {
        return await _contextWrapper.transactionRepository.GetAtmWithdrawTotal();
    }

    public async Task<int> GetTransactionsOfMounthService()
    {
        return await _contextWrapper.transactionRepository.GetTransactionsOfMounth();
    }

    public async Task<int> GetTransactionsOfSixMounthService()
    {
        return await _contextWrapper.transactionRepository.GetTransactionsOfSixMounth();
    }

    public async Task<int> GetTransactionsOfYearService()
    {
        return await _contextWrapper.transactionRepository.GetTransactionsOfYear();
    }
}
