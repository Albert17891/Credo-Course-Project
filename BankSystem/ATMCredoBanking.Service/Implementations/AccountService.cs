namespace AtmCredoBanking.Service.Implementations;

using AtmCredoBanking.Service.Abstractions;
using AtmCredoBanking.Service.Models;
using BankSystem.DataAccess.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

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

        if(await _context.cardRepository.CheckExpiredCards(checkCard.Id))
        {
            checkCard = null;
            return checkCard.Adapt<CardAtmServiceModel>();
        }
        else if(await _context.cardRepository.CheckReplaceableCards(checkCard.Id))
        {
            var result = checkCard.Adapt<CardAtmServiceModel>();
            result.Replaceable = true;
            return result;
        }

        return checkCard.Adapt<CardAtmServiceModel>();
    }
}