namespace CredoReport.Service.Abstractions;
public interface ITransactionStatisticService
{
    Task<int> GetTransactionsQuantityService(int Id);

    Task<decimal> GetAtmWithdrawTotalService();
}
