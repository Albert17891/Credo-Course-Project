using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BankSystem.DataAccess.Servcices;
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
}
