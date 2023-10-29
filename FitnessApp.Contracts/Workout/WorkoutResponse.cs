namespace FitnessApp.Contracts.Workout;

public record WorkoutResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Exercises
);