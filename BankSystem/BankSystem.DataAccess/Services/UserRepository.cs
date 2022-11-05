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
	public async Task<int> GetUsersQuantity(double Id)
	{
		return await _context.Users.Where(x => EF.Functions.DateDiffDay(x.RegisterTime, DateTime.Now) <= Id)
					   .CountAsync();
	}
}