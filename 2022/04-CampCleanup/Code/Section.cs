namespace Code;

public class Section
{
    public List<Assignment> Assignments { get; init; } = new();

    public static Section Initialize(string assignments)
    {
        var pairs = assignments.Split(",");
        return new Section
        {
            Assignments = pairs.Select(p => Assignment.Initialize(p)).ToList()
        };
    }

    public bool AssignmentsAreContained
    {
        get 
        {
            return Assignment.IsFullyContained(Assignments[0], Assignments[1]);
        }
    }
}
