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

        if (choseType == 30)
        {
            var result = await _service.GetTransactionsOfMounthService();
            return View(new TransactionQuantity { Quantity = result });
        }
        else if (choseType == 60)
        {
            var result = await _service.GetTransactionsOfSixMounthService() ;
            return View(new TransactionQuantity { Quantity=result});
        }
        else
        {
            var result = await _service.GetTransactionsOfYearService();
            return View(new TransactionQuantity { Quantity = result });
        }
       
    }
   [Route("TransactionFeeQuantity")]
    [HttpGet("Id")]
    public async Task<IActionResult> TransactionFeeQuantity(int Id)
    {
      
        if(Id==30)
        {
           
            return View();
        }
        else if(Id==60)
        {
            return View();
        }
        else
        {
            return View();
        }
        return Ok();
    }

    public async Task<IActionResult> AverageTransactionFee()
    {
        


        return View();

    }

    public async Task<IActionResult> AtmMoneyQuantity()
    {
        var result = await _service.GetAtmWithdrawTotalService();
        return View(new MoneyQuantity { Quantity=result});
    }

}
