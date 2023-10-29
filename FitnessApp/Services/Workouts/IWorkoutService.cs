using ErrorOr;
using FitnessApp.Models;

namespace FitnessApp.Services.Workouts;

public interface IWorkoutService
{
    ErrorOr<Created> CreateWorkout(Workout workout);
    ErrorOr<Workout> GetWorkout(Guid id);
    ErrorOr<UpsertedWorkout> UpsertWorkout(Workout workout);
    ErrorOr<Deleted> DeleteWorkout(Guid id);
}