namespace CredoReport.Service.Abstractions;
public interface ITransactionStatisticService
{
    Task<int> GetTransactionsOfMounthService();
    Task<int> GetTransactionsOfSixMounthService();
    Task<int> GetTransactionsOfYearService();

    Task<decimal> GetAtmWithdrawTotalService();
}
