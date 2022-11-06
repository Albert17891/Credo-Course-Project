namespace CredoATM.Controllers;

using AtmCredoBanking.Service.Abstractions;
using CredoATM.Infastructure.ServiceCollectionExtensions;
using CredoATM.Models;
using Microsoft.AspNetCore.Mvc;

public class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }
    public IActionResult Index()
    {
        var card = HttpContext.Session.Get<CreditCardAtm>("CreditCart");

        return View(new Check { ResultOfCheck = card.Replaceable });
    }

    public async Task<IActionResult> CheckBalance()
    {
        var card = HttpContext.Session.Get<CreditCardAtm>("CreditCart");
        var amount = await _cardService.ShowBalance(card.UserAccountId);


        return View(new Balance { Amount = amount });
    }

    [HttpGet]
    public IActionResult ChangePin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePin(ChangePin changePin)
    {
        var card = HttpContext.Session.Get<CreditCardAtm>("CreditCart");
        await _cardService.ChangePin(card.Id, changePin.Pin);

        return RedirectToAction("Index");
    }

    [Route("Withdraw")]
    [HttpGet]
    public IActionResult Withdraw()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Withdrawal(Balance balance)
    {
        var card = HttpContext.Session.Get<CreditCardAtm>("CreditCart");
        if (await _cardService.WithDraw(card.UserAccountId, balance.Amount))
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("NotEnoughMoney");
    }

    public IActionResult NotEnoughMoney()
    {
        return View();
    }
}