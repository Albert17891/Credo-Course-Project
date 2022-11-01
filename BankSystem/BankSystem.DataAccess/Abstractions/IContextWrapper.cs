namespace BankSystem.DataAccess.Abstractions;
public interface IContextWrapper:IDisposable
{
    ICreditCardRepository cardRepository { get; }
    IUserAccountRepository userAccountRepository { get; }
    void Complete();
}
