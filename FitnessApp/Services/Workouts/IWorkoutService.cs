using FitnessApp.Models;

namespace FitnessApp.Services.Workouts;

public interface IWorkoutService
{
    void CreateWorkout(Workout workout);
    Workout GetWorkout(Guid id);
}