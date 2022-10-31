namespace BankSystem.DataAccess.Abstractions;
public interface IBaseRepository<T>
{
    List<T> GetAll();
    T GetByKey(string key);
    void Update(T entity);

    void AddEntity(T entity);

}
