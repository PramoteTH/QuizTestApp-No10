using Microsoft.AspNetCore.Mvc;
using QuizTestApp.Models;

namespace QuizTestApp.Controllers;

[ApiController]
public class HealthcheckController : ControllerBase
{
    public HealthcheckController()
    {
    }
    [HttpGet("healthcheck")]
    public IActionResult Healthcheck()
    {
        return Ok(new {
            status = 200,
            message = "Ok"
        });
    }
}