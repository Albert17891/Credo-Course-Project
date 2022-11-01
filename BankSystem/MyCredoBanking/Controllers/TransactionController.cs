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
    public IActionResult GetIdNumber()
    {
        return View();
    }

    [Route("SendToOther")]
    [HttpGet("Id")]
    public IActionResult SendToOther(string IdNumber)
    {
      //  var accounts=blaa
        return View();
    }

    [Route("SendToMe")]
    [HttpGet]
    public async Task<IActionResult> MyAccounts()
    {
        //var accounts = await GetMyAccounts();
        //return View(accounts);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> ChargeAccounts()
    {
        //var accounts = await GetMyAccounts();
        //return View(accounts);
        return Ok();
    }



    //public async Task<IActionResult> SendToMe()
    //{

    //}
}
