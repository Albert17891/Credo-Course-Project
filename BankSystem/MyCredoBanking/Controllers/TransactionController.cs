using Microsoft.AspNetCore.Mvc;

namespace MyCredoBanking.Controllers;
public class TransactionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("SendToOther")]
    [HttpGet]
    public IActionResult SendToOther()
    {
        return View();
    }

    [Route("SendToMe")]
    [HttpGet]
    public async Task<IActionResult> SendToMe()
    {
        //var accounts = await GetMyAccounts();
        //return View(accounts);
        return Ok();
    }


    //public async Task<IActionResult> SendToMe()
    //{

    //}
}
