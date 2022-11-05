namespace MyCredoBanking.Controllers;

using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Infrastracture.ServiceCollectionExtensions;
using MyCredoBanking.Models.Response;
using MyCredoBanking.Models.Transaction;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;


[Authorize(Roles = "User")]
public class InnerTransactionController : Controller
{
    private readonly UserManager<AppUser> _userManger;
    private readonly IUserService _userService;
    private readonly ITransactionHelperService _transactionHelper;

    public InnerTransactionController(UserManager<AppUser> userManager, IUserService userService
        , ITransactionHelperService transactionHelper)
    {
        _userManger = userManager;
        _userService = userService;
        _transactionHelper = transactionHelper;
    }


    [Route("GetFirstAccount")]
    [HttpGet]
    public async Task<IActionResult> GetFirstAccount()
    {

        var accounts = await _transactionHelper.GetAccounts(_userManger, User.Identity.Name);
        if (accounts is not null)
        {
            return View(accounts.Adapt<List<UserAccountResponse>>());
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

        var firstAccountId = (int)TempData["FirstAccountId"];

        var allAccounts = await _transactionHelper.GetAccounts(_userManger, User.Identity.Name, firstAccountId);

        TempData["FirstAccountId"] = firstAccountId;

        if (allAccounts is not null)
        {
            return View(allAccounts.Adapt<List<UserAccountResponse>>());
        }
        return View();
    }

    public async Task<IActionResult> SendToMe(int Id)
    {

        var transaction = new Transaction()
        {
            SenderAccountId = (int)TempData["FirstAccountId"],
            RecieverAccountId = Id,
            Amount = TempData.Get<decimal>("Amount")
        };

        if (await _userService.Transaction(transaction.Adapt<TransactionServiceModel>()))
        {
            return RedirectToAction("Index", "User");
        }

        return RedirectToAction("NotEnoughMoney");
    }

    public IActionResult NotEnoughMoney()
    {
        return View();
    }

}