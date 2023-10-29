using Microsoft.AspNetCore.Mvc;
using FitnessApp.Contracts.Workout;
using FitnessApp.Models;
using FitnessApp.Services.Workouts;
using ErrorOr;

namespace FitnessApp.Controllers;

public class WorkoutsController : ApiController
{
    private readonly IWorkoutService _workoutService;

    public WorkoutsController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpPost]
    public IActionResult CreateWorkout(CreateWorkoutRequest request)
    {
        ErrorOr<Workout> requestToWorkoutResults = Workout.From(request);

        if (requestToWorkoutResults.IsError)
        {
            return Problem(requestToWorkoutResults.Errors);
        }

        var workout = requestToWorkoutResults.Value;

        ErrorOr<Created> createWorkoutResult = _workoutService.CreateWorkout(workout);

        return createWorkoutResult.Match(
            created => CreatedAtGetWorkout(workout),
            Problem
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetWorkout(Guid id)
    {
        ErrorOr<Workout> getWorkoutResult = _workoutService.GetWorkout(id);

        return getWorkoutResult.Match(
            workout => Ok(MapWorkoutResponse(workout)),
            Problem
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertWorkout(Guid id, UpsertWorkoutRequest request)
    {
        ErrorOr<Workout> requestToWorkoutResult = Workout.From(id, request);

        if (requestToWorkoutResult.IsError)
        {
            return Problem(requestToWorkoutResult.Errors);
        }

        var workout = requestToWorkoutResult.Value;

        ErrorOr<UpsertedWorkout> upsertWorkoutResult = _workoutService.UpsertWorkout(workout);

        return upsertWorkoutResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetWorkout(workout) : NoContent(),
            Problem
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteWorkout(Guid id)
    {
        ErrorOr<Deleted> deleteWorkoutResult = _workoutService.DeleteWorkout(id);

        return deleteWorkoutResult.Match(
            deleted => NoContent(),
            Problem
        );
    }

    private static WorkoutResponse MapWorkoutResponse(Workout workout)
    {
        return new WorkoutResponse(
            workout.Id,
            workout.Name,
            workout.Description,
            workout.StartDateTime,
            workout.EndDateTime,
            workout.LastModifiedDateTime,
            workout.Exercises
        );
    }

    private IActionResult CreatedAtGetWorkout(Workout workout)
    {
        return CreatedAtAction(
            actionName: nameof(GetWorkout),
            routeValues: new { id = workout.Id },
            value: MapWorkoutResponse(workout)
        );
    }
}