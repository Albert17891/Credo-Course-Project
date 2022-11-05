namespace AtmCredoBanking.Service.Implementations;

using AtmCredoBanking.Service.Abstractions;
using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;


public class CardService : ICardService
{
    private readonly IContextWrapper _context;

    public CardService(IContextWrapper context)
    {
        _context = context;
    }

    public async Task ChangePin(int cardId, string pin)
    {
        var card = await _context.cardRepository.GetByKeyAsync(cardId);

        card.Pin = pin;

        _context.Complete();
    }

    public async Task<decimal> ShowBalance(int acountId)
    {
        var account = await _context.userAccountRepository.GetByKeyAsync(acountId);

        return account.Amount;

    }

    public async Task<bool> WithDraw(int acountId, decimal amount)
    {
        var account = await _context.userAccountRepository.GetByKeyAsync(acountId);

        var fee = amount * 2 / 100;

        var totalmoney = amount + fee;

        if (account.Amount < totalmoney) return false;

        account.Amount -= totalmoney;

        await _context.transactionRepository.AddEntityAsync(new Transactions
        {
            Currency = account.Currency,
            TransferAmount = totalmoney,
            TransferFee = fee,
            UserId = account.UserId,
            TransactionType = TransactionType.AtmTransaction,
            TransactionDate = DateTime.Now
        });

        _context.Complete();

        return true;
    }
}