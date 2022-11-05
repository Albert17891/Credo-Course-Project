namespace CredoReport.Controllers;

using CredoReport.Models.TransactionStastistic;
using CredoReport.Service.Abstractions;
using Mapster;
using Microsoft.AspNetCore.Mvc;

[Route("TransactionStatistic")]
public class TransactionStatisticController : Controller
{
    private readonly ITransactionStatisticService _service;

    public TransactionStatisticController(ITransactionStatisticService service)
    {
        _service = service;
    }

    [Route("Index")]
    [HttpGet]
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
        var fee =await _service.GetTotalIncomeService(Id);
        return View(fee.Adapt<TransactionFee>());
    }

    [Route("AverageTransactionFee")]
    [HttpGet]
    public async Task<IActionResult> AverageTransactionFee()
    {
        var averageFee = await _service.GetAvgIncomeService();
        return View(averageFee.Adapt<TransactionFee>()) ;
    }

    [Route("AtmMoneyQuantity")]
    [HttpGet]
    public async Task<IActionResult> AtmMoneyQuantity()
    {
        var result = await _service.GetWithdrawTotalService();
        return View(new MoneyQuantity { Quantity = result });
    }
}