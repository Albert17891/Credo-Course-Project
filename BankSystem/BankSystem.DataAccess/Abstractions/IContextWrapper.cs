namespace BankSystem.DataAccess.Abstractions;
public interface IContextWrapper:IDisposable
{
    ICreditCardRepository cardRepository { get; }
    
    IUserAccountRepository userAccountRepository { get; }

    ITransactionRepository transactionRepository { get; }
    
    IUserRepository userRepository { get; }
    void Complete();
}