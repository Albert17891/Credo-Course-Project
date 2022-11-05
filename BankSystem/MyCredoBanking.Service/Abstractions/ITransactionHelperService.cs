namespace MyCredoBanking.Service.Abstractions;

using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using MyCredoBanking.Service.Model;

public interface ITransactionHelperService
{
    Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName);
    Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName,int firstAccountId);
    Task<IList<UserAccountServiceModel>> GetAccoutsWithIdNumber(UserManager<AppUser> userManager,string IdNumber);
}