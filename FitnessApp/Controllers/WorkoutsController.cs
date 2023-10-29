using Microsoft.AspNetCore.Mvc;
using FitnessApp.Contracts.Workout;
using FitnessApp.Models;
using System.Runtime.CompilerServices;
using FitnessApp.Services.Workouts;

namespace FitnessApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutsController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpPost]
    public IActionResult CreateWorkout(CreateWorkoutRequest request)
    {
        var workout = new Workout(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Exercises
        );

        _workoutService.CreateWorkout(workout);

        var response = new WorkoutResponse(
            workout.Id,
            workout.Name,
            workout.Description,
            workout.StartDateTime,
            workout.EndDateTime,
            workout.LastModifiedDateTime,
            workout.Exercises
        );

        return CreatedAtAction(
            actionName: nameof(GetWorkout),
            routeValues: new { id = workout.Id },
            value: response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetWorkout(Guid id)
    {
        Workout workout = _workoutService.GetWorkout(id);

        var response = new WorkoutResponse(
            workout.Id,
            workout.Name,
            workout.Description,
            workout.StartDateTime,
            workout.EndDateTime,
            workout.LastModifiedDateTime,
            workout.Exercises
        );
        
        return Ok(response);
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