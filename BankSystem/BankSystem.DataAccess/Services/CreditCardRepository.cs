namespace BankSystem.DataAccess.Services;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> CheckExpiredCards(int Id)
    {
        return await Table.Where(x => x.Id == Id)
                          .Select(x => x.CardExpireDate < DateTime.Now)
                          .SingleOrDefaultAsync();
    }

    public async Task<bool> CheckReplaceableCards(int Id)
    {
        return await Table.Where(x => x.Id == Id)
                          .Select(x => x.CardExpireDate < DateTime.Now.AddDays(90))
                          .SingleOrDefaultAsync();
    }
}