using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;

public interface ITransactionRepository : IBaseRepository<Transactions>
{
    Task<int> GetTransactionsOfMounth();
    Task<int> GetTransactionsOfSixMounth();
    Task<int> GetTransactionsOfYear();

    Task<decimal> GetAtmWithdrawTotal();
}
