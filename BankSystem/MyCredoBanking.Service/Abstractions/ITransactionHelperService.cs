using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Service.Abstractions;
public interface ITransactionHelperService
{
    Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName);
    Task<IList<UserAccountServiceModel>> GetAccounts(UserManager<AppUser> userManager, string userName,int firstAccountId);
    Task<IList<UserAccountServiceModel>> GetAccoutsWithIdNumber(UserManager<AppUser> userManager,string IdNumber);


}
