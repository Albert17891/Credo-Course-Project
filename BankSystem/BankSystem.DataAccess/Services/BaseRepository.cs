using BankSystem.DataAccess.Abstractions;
using BankSystem.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Servcices;
public class BaseRepository<T>:IBaseRepository<T> where T :class
{
	private readonly IdentityContext _context;
	private readonly DbSet<T> _dbSet;

	public BaseRepository(IdentityContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}

	public IQueryable<T> Table
	{
		get { return _dbSet; }
	}

	public async Task AddEntityAsync(T entity)
	{
		await _context.AddAsync(entity);
	}

	public async Task<List<T>> GetAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T> GetByKeyAsync(params object[] key)
	{
		return await _dbSet.FindAsync(key);
	}

	public void Update(T entity)
	{
		_context.Update(entity);
	}
}
