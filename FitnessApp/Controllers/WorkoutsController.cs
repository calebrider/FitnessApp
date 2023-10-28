using Microsoft.AspNetCore.Mvc;
using FitnessApp.Contracts.Workout;

namespace FitnessApp.Controllers;

[ApiController]
public class WorkoutsController : ControllerBase {
    [HttpPost("/workouts")]
    public IActionResult CreateWorkout(CreateWorkoutRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/workouts/{id:guid}")]
    public IActionResult GetWorkout(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/workouts/{id:guid}")]
    public IActionResult UpsertWorkout(Guid id, UpsertWorkoutRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/workouts/{id:guid}")]
    public IActionResult DeleteWorkout(Guid id)
    {
        return Ok(id);
    }
}