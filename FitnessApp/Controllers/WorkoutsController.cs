using Microsoft.AspNetCore.Mvc;
using FitnessApp.Contracts.Workout;

namespace FitnessApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutsController : ControllerBase {
    [HttpPost()]
    public IActionResult CreateWorkout(CreateWorkoutRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetWorkout(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertWorkout(Guid id, UpsertWorkoutRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteWorkout(Guid id)
    {
        return Ok(id);
    }
}