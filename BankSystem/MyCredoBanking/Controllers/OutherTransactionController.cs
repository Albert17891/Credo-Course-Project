namespace MyCredoBanking.Controllers;

using BankSystem.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Infrastracture.ServiceCollectionExtensions;
using MyCredoBanking.Models.Request;
using MyCredoBanking.Models.Transaction;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;


[Authorize(Roles = "User")]
public class OutherTransactionController : Controller
{
    private readonly UserManager<AppUser> _userManger;
    private readonly IUserService _userService;
    private readonly ITransactionHelperService _transactionHelper;

    public OutherTransactionController(UserManager<AppUser> userManager, IUserService userService
        , ITransactionHelperService transactionHelper)
    {
        _userManger = userManager;
        _userService = userService;
        _transactionHelper = transactionHelper;
    }


    [HttpGet]
    public IActionResult GetIdNumber()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> GetReciverAccounts(IdNumberCheck idNumberCheck)
    {
        var accounts = await _transactionHelper.GetAccoutsWithIdNumber(_userManger, User.Identity.Name, idNumberCheck.IdNumber);

        if (accounts is not null)
        {
            return View(accounts.Adapt<List<UserAccountRequest>>());
        }

        return RedirectToAction("EmptyAccount", "InnerTransaction");
    }

    [HttpGet]
    public IActionResult HowMuchMoney(int Id)
    {
        TempData["AccoundId"] = Id;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetSenderAccounts(HowMuchMoney howMuch)
    {

        TempData.Put("Amount", howMuch.Amount);

        var accounts = await _transactionHelper.GetAccounts(_userManger, User.Identity.Name);

        if (accounts is not null)
        {
            return View(accounts.Adapt<List<UserAccountRequest>>());
        }

        return RedirectToAction("EmptyAccount", "InnerTransaction");
    }

    [Route("SendToOther")]
    [HttpGet("{Id}")]
    public async Task<IActionResult> SendToOther(int Id)
    {

        var transaction = new Transaction()
        {
            RecieverAccountId = (int)TempData["AccoundId"],
            SenderAccountId = Id,
            Amount = TempData.Get<decimal>("Amount")
        };
        if (await _userService.Transaction(transaction.Adapt<TransactionServiceModel>()))
        {
            return RedirectToAction("Index", "User");
        }

        return RedirectToAction("NotEnoughMoney", "InnerTransaction");
    }
}