using CredoReport.Models.TransactionStastistic;
using CredoReport.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CredoReport.Controllers;
public class TransactionStatisticController : Controller
{
    private readonly ITransactionStatisticService _service;

    public TransactionStatisticController(ITransactionStatisticService service)
    {
        _service = service;
    }
    public IActionResult Index()
    {
        return View();
    }

    [Route("QuantityTransaction")]
    [HttpGet("choseType")]
    public async Task<IActionResult> QuantityTransaction(int choseType)
    {
        var result = await _service.GetTransactionsQuantityService(choseType);
        return View(new TransactionQuantity { Quantity = result });
    }
    [Route("TransactionFeeQuantity")]
    [HttpGet("Id")]
    public async Task<IActionResult> TransactionFeeQuantity(int Id)
    {

        return View();        
    }

    public async Task<IActionResult> AverageTransactionFee()
    {



        return View();

    }

    public async Task<IActionResult> AtmMoneyQuantity()
    {
        var result = await _service.GetAtmWithdrawTotalService();
        return View(new MoneyQuantity { Quantity = result });
    }

}
