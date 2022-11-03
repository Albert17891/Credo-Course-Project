using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Services;
public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
{
    private readonly IdentityContext _context;
    public CreditCardRepository(IdentityContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<CreditCard>> GetAllCreditCard(string key)
    {
        return await Table.Where(x => x.UserId == key).ToListAsync();
    }

    public async Task<CreditCard> GetCardWithNumberAndPin(string number, string pin)
    {
        return await Table.Where(x => x.CardNumber == number && x.Pin == pin).SingleOrDefaultAsync();
    }

    public async Task<List<CreditCard>> GetExpiredCards()
    {
        return await Table.Where(x => x.CardExpireDate < DateTime.Now).ToListAsync();
    }

    public async Task<List<CreditCard>> GetReplaceableCards()
    {
        return await Table.Where(x => x.CardExpireDate < DateTime.Now.AddDays(90)).ToListAsync();
    }
}
