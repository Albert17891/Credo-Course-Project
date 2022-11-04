using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Services;
public class UserRepository : BaseRepository<AppUser>, IUserRepository
{
	private readonly IdentityContext _context;
	public UserRepository(IdentityContext context) : base(context)
	{
		_context = context;
	}

	public async Task<int> GetUsersOfOneMonth()
	{
		return await _context.Users.Where(x => EF.Functions.DateDiffDay(x.RegisterTime, DateTime.Now) <= 30)
			                       .CountAsync();
	}

	public async Task<int> GetUsersOfOneYear()
	{
        return await _context.Users.Where(x => EF.Functions.DateDiffDay(x.RegisterTime, DateTime.Now) <= 365)
                                   .CountAsync();
    }

	public async Task<int> GetUsersOfThisYear()
	{

		var check =DateTime.Now.Subtract( new DateTime(DateTime.Now.Year, 1, 1)).TotalDays;

		return await _context.Users.Where(x => EF.Functions
								   .DateDiffDay(x.RegisterTime, DateTime.Now) <= check)
                                   .CountAsync();

        
	}
}
