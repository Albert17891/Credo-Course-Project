namespace CredoReport.Service.Abstractions;
public interface IUserStatisticService
{
    Task<int> GetUsersQuantityService(double Id);
}
