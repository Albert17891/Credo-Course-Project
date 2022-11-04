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

    public async Task<int> GetTransactionsQuantityService(int Id)
    {
        return await _contextWrapper.transactionRepository.GetTransactionsQuantity(Id);
    }
}
