using AppleStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DolarController : ControllerBase
{
    private readonly DolarService _dolarService;

    public DolarController(DolarService dolarService)
    {
        _dolarService = dolarService;
    }

    [HttpGet("oficial")]
    public async Task<IActionResult> ObtenerDolar()
    {
        var dolar =
            await _dolarService.ObtenerDolarOficial();

        return Ok(dolar);
    }
}