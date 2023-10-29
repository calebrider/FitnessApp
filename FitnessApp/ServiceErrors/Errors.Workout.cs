using ErrorOr;

namespace FitnessApp.ServiceErrors;

public static class Errors
{
    public static class Workout
    {
        public static Error NotFound => Error.NotFound(
            code: "Workout.NotFound",
            description: "Workout not found"
        );

        public static Error InvalidName => Error.Validation(
            code: "Workout.InvalidName",
            description: $"Workout name must be at least {Models.Workout.MinNameLength} " +
                $"and at most {Models.Workout.MaxNameLength} characters long"
        );
    }
}