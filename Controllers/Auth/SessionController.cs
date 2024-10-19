using Microsoft.AspNetCore.Mvc;

namespace CapacitaDigitalApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SessionController : Controller
{
    [HttpPost("set")]
    public IActionResult SetSessionData([FromBody] string value)
    {
        HttpContext.Session.SetString("SessionKey", value);
        return Ok("Dados guardados na sessão");
    }

    [HttpGet("get")]
    public IActionResult GetSessionData()
    {
        var value = HttpContext.Session.GetString("SessionKey");
        return Ok(value ?? "Nenhum dado encontrado");
    }

    [HttpGet("clear")]
    public IActionResult ClearSessionData()
    {
        HttpContext.Session.Clear();
        return Ok("Dados removidos da sessão");
    }
}