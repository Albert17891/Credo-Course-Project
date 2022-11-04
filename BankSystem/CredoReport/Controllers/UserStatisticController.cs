using CredoReport.Models.UserStatistic;
using CredoReport.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CredoReport.Controllers;
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

    public async Task<IActionResult> GetUserQuantityFromPerMonth()
    {
        var result = await userStatistic.GetUsersOneMonthService();
        return View(new UserQuantity { Quantity = result });
    }

    public async Task<IActionResult> GetUserQuantityFromOneYear()
    {
        var result = await userStatistic.GetUsersFromThisYearService();
        return View(new UserQuantity { Quantity = result });
    }

    public async Task<IActionResult> GetUserQuantityFromThisYear()
    {
        var result = await userStatistic.GetUsersFromOneYearService();
        return View(new UserQuantity { Quantity = result });

    }
}
