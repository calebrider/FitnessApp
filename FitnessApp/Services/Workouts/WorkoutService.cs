using FitnessApp.Models;

namespace FitnessApp.Services.Workouts;

public class WorkoutService : IWorkoutService
{
    private static readonly Dictionary<Guid, Workout> _workouts = new();

    public void CreateWorkout(Workout workout)
    {
        _workouts.Add(workout.Id, workout);
    }

    public Workout GetWorkout(Guid id)
    {
        return _workouts[id];
    }

    public void UpsertWorkout(Workout workout)
    {
        _workouts[workout.Id] = workout;
    }

    public void DeleteWorkout(Guid id)
    {
        _workouts.Remove(id);
    }
}