namespace BankSystem.DataAccess.Services;

using BankSystem.DataAccess.Abstractions;
using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

public class UserRepository : BaseRepository<AppUser>, IUserRepository
{
	private readonly IdentityContext _context;
	public UserRepository(IdentityContext context) : base(context)
	{
		_context = context;
	}
	public async Task<int> GetUsersQuantity(int Id)
	{
		switch (Id)
		{
			case 30:
				{
					//For Month
					return await _context.Users.Where(x => EF.Functions.DateDiffDay(x.RegisterTime, DateTime.Now) <= 30)
								   .CountAsync();
					break;
				}
			case 180:
				{
					//For This Year
					var check = DateTime.Now.Subtract(new DateTime(DateTime.Now.Year, 1, 1)).TotalDays;

					return await _context.Users.Where(x => EF.Functions
											   .DateDiffDay(x.RegisterTime, DateTime.Now) <= check)
											   .CountAsync();
					break;
				}
			default:
				{
					//For One Year
					return await _context.Users.Where(x => EF.Functions.DateDiffDay(x.RegisterTime, DateTime.Now) <= 365)
								  .CountAsync();
				}
		}
	}

	public async Task<int> UsersRegisteredLast30Days()
	{
		var fromDate = DateTime.Today.AddDays(-30);

		return await _context.Users.Where(x => x.RegisterTime >= fromDate)
					   .CountAsync();
	}

    public async Task<int> UsersRegisteredLastOneYear()
    {
		var fromDate = DateTime.Today.AddMonths(-12);

		return await _context.Users.Where(x => x.RegisterTime >= fromDate)
					   .CountAsync();
	}

    public async Task<int> UsersRegisteredthisYear()
    {
		var fromDate = new DateTime(DateTime.Now.Year, 1, 1);

		return await _context.Users.Where(x => x.RegisterTime >= fromDate)
					   .CountAsync();
	}
}