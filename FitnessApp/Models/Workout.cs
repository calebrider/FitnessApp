using ErrorOr;
using FitnessApp.Contracts.Workout;
using FitnessApp.ServiceErrors;

namespace FitnessApp.Models;

public class Workout
{
    public const int MinNameLength = 1;
    public const int MaxNameLength = 50;
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Exercises { get; }

    private Workout(
        Guid id, 
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime, 
        DateTime lastModifiedDateTime, 
        List<string> exercises)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Exercises = exercises;
    }

    public static ErrorOr<Workout> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> exercises,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Workout.InvalidName);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Workout(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            exercises
        );
    }

    public static ErrorOr<Workout> From(CreateWorkoutRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Exercises
        );
    }

    public static ErrorOr<Workout> From(Guid id, UpsertWorkoutRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Exercises,
            id
        );
    }
}
