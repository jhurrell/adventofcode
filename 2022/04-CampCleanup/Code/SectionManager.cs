namespace Code;

public class SectionManager
{
    public List<Section> Sections { get; init; } = new();

    public static SectionManager Initialize(List<string> assignments)
    {
        return new SectionManager 
        {
            Sections = assignments.Select(a => Section.Initialize(a)).ToList()
        };
    }

    public int FullyContainedCount
    {
        get
        {
            return Sections.Where(s => s.AssignmentsAreContained).Count();
        }
    }
}