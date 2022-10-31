namespace BankSystem.DataAccess.Abstractions;
public interface IContextWrapper:IDisposable
{
    ICreditCardRepository cardRepository { get; }
    IUserAccountRepository userAccountRepository { get; }
    Task Complete();
}
