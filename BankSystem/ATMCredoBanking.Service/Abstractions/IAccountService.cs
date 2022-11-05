namespace AtmCredoBanking.Service.Abstractions;

using AtmCredoBanking.Service.Models;

public interface IAccountService
{
    Task<CardAtmServiceModel> CheckCard(string creditCardNumber, string pin);
}
