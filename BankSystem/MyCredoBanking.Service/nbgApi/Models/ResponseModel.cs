namespace MyCredoBanking.Service.nbgApi.Models;

public class ResponseModel
{
    public DateTime date { get; set; }

    public CurrencyModel[] currencies { get; set; }
}
