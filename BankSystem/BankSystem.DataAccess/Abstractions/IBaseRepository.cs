namespace BankSystem.DataAccess.Abstractions;
public interface IBaseRepository<T>
{
    IQueryable<T> Table { get; }
    Task<List<T>> GetAllAsync();
    Task<T> GetByKeyAsync(params object[] key);
    void Update(T entity);

    Task AddEntityAsync(T entity);

}
