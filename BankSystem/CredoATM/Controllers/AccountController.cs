using AtmCredoBanking.Service.Abstractions;
using CredoATM.Infastructure.ServiceCollectionExtensions;
using CredoATM.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CredoATM.Controllers;
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public IActionResult CreditCardLogin()
    {
        return View();
    }

    public async Task<IActionResult> CheckCard(CreditCardLogin creditCard)
    {
        var result = await _accountService.CheckCard(creditCard.CreditCartNumber, creditCard.Pin);

        if (result is not null)
        {
            HttpContext.Session.Set<CreditCardAtm>("CreditCart", result.Adapt<CreditCardAtm>());
            return RedirectToAction("Index", "Card");
        }

        return RedirectToAction("ExpiredCard");
    }

    public IActionResult ExpiredCard()
    {
        return View();
    }
}
