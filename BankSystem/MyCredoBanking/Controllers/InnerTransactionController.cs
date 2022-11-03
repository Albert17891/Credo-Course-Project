using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Infrastracture.ServiceCollectionExtensions;
using MyCredoBanking.Models.Response;
using MyCredoBanking.Models.Transaction;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Controllers;
public class InnerTransactionController : Controller
{
    private readonly UserManager<AppUser> _userManger;
    private readonly IUserService _userService;

    public InnerTransactionController(UserManager<AppUser> userManager, IUserService userService)
    {
        _userManger = userManager;
        _userService = userService;
    }


    [Route("GetFirstAccount")]
    [HttpGet]
    public async Task<IActionResult> GetFirstAccount()
    {
        var user = await _userManger.FindByNameAsync(User.Identity?.Name);
        var account = await _userService.GetAllAccount(user.Id);
        if (account is not null)
        {
            return View(account.Adapt<List<UserAccountResponse>>());
        }
        return View();
    }

    [HttpGet]
    public IActionResult HowMuchMoney(int Id)
    {
        TempData["FirstAccountId"] = Id;

        return View();
    }

    [Route("GetSecondAccount")]
    [HttpPost]
    public async Task<IActionResult> GetSecondAccount(HowMuchMoney howMuch)
    {
        TempData.Put("Amount", howMuch.Amount);

        var user = await _userManger.FindByNameAsync(User.Identity?.Name);
        var allAccounts = await _userService.GetAllAccount(user.Id);

        var firstAccountId = (int)TempData["FirstAccountId"];
        TempData["FirstAccountId"] = firstAccountId;

        var accounts = allAccounts.Where(x => x.Id != firstAccountId);

        if (accounts is not null)
        {
            return View(accounts.Adapt<List<UserAccountResponse>>());
        }
        return View();
    }

    public async Task<IActionResult> SendToMe(int Id)
    {


       

        var transaction = new Transaction()
        {
            SenderAccountId= (int)TempData["FirstAccountId"],
             ReciverAccountId= Id,
            Amount = TempData.Get<decimal>("Amount")
        };

        await _userService.InnerTransaction(transaction.Adapt<TransactionServiceModel>());
        return Ok();
    }



}
