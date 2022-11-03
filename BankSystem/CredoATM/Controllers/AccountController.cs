using CredoATM.Infastructure.ServiceCollectionExtensions;
using CredoATM.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyCredoBanking.Service.Abstractions;

namespace CredoATM.Controllers;
public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    public IActionResult CreditCardLogin()
    {
        return View();
    }

    public async Task<IActionResult>CheckCard(CreditCardLogin creditCard)
    {
        var result = await _userService.CheckCardService(creditCard.CreditCartNumber, creditCard.Pin);

        if(result is not null)
        {
            HttpContext.Session.Set<CreditCardResponse>("CreditCart", result.Adapt<CreditCardResponse>() );
            return RedirectToAction("Index", "Card");
        }
        return RedirectToAction("Error","Home");
    }
}
