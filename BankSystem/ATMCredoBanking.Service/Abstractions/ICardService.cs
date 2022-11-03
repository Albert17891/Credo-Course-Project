namespace AtmCredoBanking.Service.Abstractions;

public interface ICardService
{
    Task ChangePin(int cardId, string pin);

    Task WithDraw(int acountId, decimal balace);

    Task<decimal> ShowBalance(int acountId);
}
