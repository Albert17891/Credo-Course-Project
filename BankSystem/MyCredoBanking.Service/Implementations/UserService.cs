using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using Mapster;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

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

    public async Task InnerTransaction(TransactionServiceModel transaction)
    {
        var result = transaction.Adapt<Transactions>();

        ConfigureTrans(ref result);

        var Sender = await _context.userAccountRepository.GetByKeyAsync();

        var reciever = await _context.userAccountRepository.GetByKeyAsync();

        if (Sender == null) throw new NullReferenceException(nameof(Sender));

        if (reciever == null) throw new NullReferenceException(nameof(reciever));

        if (Sender.Amount < transaction.TransferAmount + transaction.TransferFee) throw new InvalidOperationException("Not Enough Balance");

        Sender.Amount -= reciever.Amount + result.TransferFee;

        await _context.transactionRepository.AddEntityAsync(result);

        _context.Complete();
    }

    private static void ConfigureTrans(ref Transactions transaction)
    {
        if (transaction.UserId == transaction.ReceiverUserId)
        {
            transaction.TransactionType = TransactionType.InnerTransaction;
            transaction.TransferFee = 0;
            transaction.TransactionIncome = 0;
        }
        else
        {
            transaction.TransactionType = TransactionType.OuterTransaction;
            transaction.TransferFee = transaction.TransferAmount * 0.01m + 1;
            transaction.TransactionIncome = transaction.TransferFee;
        }
    }
}
