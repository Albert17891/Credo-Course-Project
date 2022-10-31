namespace BankSystem.DataAccess.Abstractions;
public interface IContextWrapper
{
    ICreditCardRepository cardRepository { get; }
    IUserAccountRepository userAccountRepository { get; }
    void Complete();
}
