using Microsoft.AspNetCore.Mvc;
using Dev.Infrastructure.Data;

namespace Dev.Plugin.ChitmeoBank.Controllers;

[ApiController]
[Route("api/cmb/[controller]")]
public class ScriptController : ControllerBase
{
    private readonly BankDbContext _context;

    public ScriptController(BankDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetScriptAsync()
    {
        string script = _context.GenerateCreateScript();
        return Ok(script);
    }
}
