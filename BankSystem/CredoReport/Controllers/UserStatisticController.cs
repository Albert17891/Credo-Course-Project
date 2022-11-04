using Microsoft.AspNetCore.Mvc;

namespace CredoReport.Controllers;
public class UserStatisticController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetUserQuantity()
    {
        return Ok();
    }

    public async Task<IActionResult> GetUserQuantityFromOneYear()
    {
        return Ok();

    }

    public async Task<IActionResult> GetUserQuantityFromPerMonth()
    {
        return Ok();

    }
}
