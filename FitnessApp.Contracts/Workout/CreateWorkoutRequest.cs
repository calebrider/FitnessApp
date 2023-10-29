namespace FitnessApp.Contracts.Workout;

public record CreateWorkoutRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Exercises
);