using BankSystem.Domain.Models;

namespace BankSystem.DataAccess.Abstractions;

public interface ITransactionRepository : IBaseRepository<Transactions>
{
    Task<int> GetTransactionsQuantity(int Id);  

    Task<decimal> GetAtmWithdrawTotal();


}
