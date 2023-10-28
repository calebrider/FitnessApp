namespace FitnessApp.Contracts.Workout;

public record UpsertWorkoutRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> exercises
);