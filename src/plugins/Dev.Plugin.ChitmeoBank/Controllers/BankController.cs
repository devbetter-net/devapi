using Dev.Plugin.ChitmeoBank.UseCases.Banks.Get;
using Dev.Plugin.ChitmeoBank.UseCases.Banks.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Plugin.ChitmeoBank.Controllers;

public class BankController : BaseController
{
    private readonly IMediator _mediator;

    public BankController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBanks()
    {
        //     var result = await _mediator.Send(new ListBanksQuery(null, null));
        //     return Ok(result);
        return Ok("Okie man");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBank(Guid id)
    {
        var result = await _mediator.Send(new GetBankQuery(id));
        return Ok(result);
    }
}
