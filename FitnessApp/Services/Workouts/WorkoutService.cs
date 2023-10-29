using ErrorOr;
using FitnessApp.Models;
using FitnessApp.ServiceErrors;

namespace FitnessApp.Services.Workouts;

public class WorkoutService : IWorkoutService
{
    private static readonly Dictionary<Guid, Workout> _workouts = new();

    public ErrorOr<Created> CreateWorkout(Workout workout)
    {
        _workouts.Add(workout.Id, workout);

        return Result.Created;
    }

    public ErrorOr<Workout> GetWorkout(Guid id)
    {
        if (_workouts.TryGetValue(id, out var workout))
        {
            return workout;
        }

        return Errors.Workout.NotFound;
    }

    public ErrorOr<UpsertedWorkout> UpsertWorkout(Workout workout)
    {
        var isNewlyCreated = !_workouts.ContainsKey(workout.Id);
        _workouts[workout.Id] = workout;

        return new UpsertedWorkout(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteWorkout(Guid id)
    {
        _workouts.Remove(id);

        return Result.Deleted;
    }
}