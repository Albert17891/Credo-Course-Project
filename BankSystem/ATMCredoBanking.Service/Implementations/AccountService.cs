using AtmCredoBanking.Service.Abstractions;
using BankSystem.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AtmCredoBanking.Service.Implementations;

public class AccountService : IAccountService
{
    private readonly IContextWrapper _context;

    public AccountService(IContextWrapper context)
    {
        _context = context;
    }

    public async Task<bool> CheckCard(string creditCardNumber, string pin)
    {
        var checkCard = await _context.cardRepository.Table.Where(x => x.CardNumber == creditCardNumber && x.Pin == pin).SingleOrDefaultAsync();

        if (checkCard.CardExpireDate < DateTime.Now) return false;

        if (checkCard == null) 
            return false;

        return true;
    }
}
