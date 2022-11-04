using AtmCredoBanking.Service.Models;

namespace AtmCredoBanking.Service.Abstractions;

public interface IAccountService 
{
    Task<CardAtmServiceModel> CheckCard(string creditCardNumber, string pin);
}
