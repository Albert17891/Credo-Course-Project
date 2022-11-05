namespace CredoReport.Controllers;

using CredoReport.Models.UserStatistic;
using CredoReport.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

public class UserStatisticController : Controller
{
    private readonly IUserStatisticService userStatistic;

    public UserStatisticController(IUserStatisticService userStatistic)
    {
        this.userStatistic = userStatistic;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserQuantity(int Id)
    {
        var result = await userStatistic.GetUsersQuantityService(Id);
        return View(new UserQuantity { Quantity = result });
    }
}