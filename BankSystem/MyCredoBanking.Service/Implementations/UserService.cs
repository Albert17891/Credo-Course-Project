using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using Mapster;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;
using MyCredoBanking.Service.nbgApi;

namespace MyCredoBanking.Service.Implementations;

public class UserService : IUserService
{
    private readonly IContextWrapper _context;

    public UserService(IContextWrapper context)
    {
        _context = context;
    }

    public async Task<IList<UserAccountServiceModel>> GetAllAccount(string userId)
    {
        var result = await _context.userAccountRepository.GetAllUserAccount(userId);

        return result.Adapt<IList<UserAccountServiceModel>>();
    }

    public async Task<IList<CreditCardServiceModel>> GetAllCard(string userId)
    {
        var result = await _context.cardRepository.GetAllCreditCard(userId);

        return result.Adapt<IList<CreditCardServiceModel>>();
    }

    public async Task Transaction(TransactionServiceModel transaction)
    {
        var senderAccount = await _context.userAccountRepository.GetByKeyAsync(transaction.SenderAccountId);
        var recieverAccount = await _context.userAccountRepository.GetByKeyAsync(transaction.RecieverAccountId);

        if (senderAccount == null) throw new NullReferenceException(nameof(senderAccount));
        if (recieverAccount == null) throw new NullReferenceException(nameof(recieverAccount));
        // to do
        var result = transaction.Adapt<Transactions>();

        result.ReceiverUserId = recieverAccount.UserId;
        result.UserId = senderAccount.UserId;
        result.TransferAmount = transaction.Amount;//????

        // ტრანზაქციის ტიპის დადგენა Inner or Outer.
        ConfigureTrans(ref result);

        // გამგზავნის ანგარიშიდან ჩამოსაჭრელი მთლიანი თანხა.
        var senderLost = result.TransferAmount + result.TransferFee;

        if (senderAccount.Amount < senderLost) throw new InvalidOperationException("Not Enough Balance");

        senderAccount.Amount -= senderLost;

        // ჩასარიცხი თანხა.
        var recieverGet = transaction.Amount;

        // კონვერტაცია
        if (senderAccount.Currency != recieverAccount.Currency)
        {
            var senderCurrencyRate = senderAccount.Currency == Currency.GEL ? 1m : Client.GetRate(senderAccount.Currency.ToString());

            var recieverCurrencyRate = recieverAccount.Currency == Currency.GEL ? 1m : Client.GetRate(senderAccount.Currency.ToString());
            
            var neededRate = senderCurrencyRate / recieverCurrencyRate;

            recieverGet *= neededRate;
        }

        recieverAccount.Amount += recieverGet;

        result.Currency = senderAccount.Currency;

        await _context.transactionRepository.AddEntityAsync(result);

        _context.Complete();
    }

    private static void ConfigureTrans(ref Transactions transaction)
    {
        if (transaction.UserId == transaction.ReceiverUserId)
        {
            transaction.TransactionType = TransactionType.InnerTransaction;
            transaction.TransferFee = 0;
        }
        else
        {
            transaction.TransactionType = TransactionType.OuterTransaction;
            transaction.TransferFee = transaction.TransferAmount * 0.01m + 0.5m;
        }
        transaction.TransactionDate = DateTime.Now;

    }
}
