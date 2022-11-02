namespace BankSystem.DataAccess.Abstractions;
public interface IContextWrapper:IDisposable
{
    ICreditCardRepository cardRepository { get; }
    
    IUserAccountRepository userAccountRepository { get; }

    ITransactionRepository transactionRepository { get; }
    
    void Complete();
}
