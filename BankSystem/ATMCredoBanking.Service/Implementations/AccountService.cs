using AtmCredoBanking.Service.Abstractions;
using AtmCredoBanking.Service.Models;
using BankSystem.DataAccess.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AtmCredoBanking.Service.Implementations;

public class AccountService : IAccountService
{
    private readonly IContextWrapper _context;

    public AccountService(IContextWrapper context)
    {
        _context = context;
    }

    public async Task<CardAtmServiceModel> CheckCard(string creditCardNumber, string pin)
    {
        var checkCard = await _context.cardRepository.Table.Where(x => x.CardNumber == creditCardNumber && x.Pin == pin).SingleOrDefaultAsync();

        return checkCard.Adapt<CardAtmServiceModel>();
    }
}
