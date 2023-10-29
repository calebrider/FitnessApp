using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}