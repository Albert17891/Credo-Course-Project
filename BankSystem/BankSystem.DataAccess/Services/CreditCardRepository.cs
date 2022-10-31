using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BankSystem.DataAccess.Servcices;
public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
{
    private readonly BankingSystemContext _context;
    public CreditCardRepository(BankingSystemContext context) : base(context)
    {
        _context = context;
    }
}
