using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Extra;

namespace BankSystem.DataAccess.Abstractions;

public interface ITransactionRepository : IBaseRepository<Transactions>
{
    Task<int> GetTransactionsQuantity(int days);

    Task<TransferIncomes> GetTotalIncome(int days);

    Task<TransferIncomes> GetAvgIncome();

    Task<decimal> GetAtmWithdrawTotal();
}
