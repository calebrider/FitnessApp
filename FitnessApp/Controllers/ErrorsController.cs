using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}