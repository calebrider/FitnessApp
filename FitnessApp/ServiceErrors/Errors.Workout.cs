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
    }
}