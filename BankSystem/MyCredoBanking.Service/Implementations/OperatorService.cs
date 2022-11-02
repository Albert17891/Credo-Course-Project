using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using Mapster;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Service.Implementations;

public class OperatorService : IOperatorService
{
    private readonly IContextWrapper _context;

    public OperatorService(IContextWrapper context)
    {
        _context = context;
    }
    public async Task AddBankAccountForUser(UserAccountServiceModel userAccount)
    {
        var accountToInsert = userAccount.Adapt<UserAccount>();

        await _context.userAccountRepository.AddEntityAsync(accountToInsert);

        _context.Complete();
    }

    public async Task AddCardForAccount(CreditCardServiceModel creditCard)
    {
        var creditCardToInsert = creditCard.Adapt<CreditCard>();

        await _context.cardRepository.AddEntityAsync(creditCardToInsert);

        _context.Complete();
    }
}
