namespace Code;

public class Part
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Number { get; set; } = string.Empty;
    public int Value => string.IsNullOrWhiteSpace(Number) ? 0 : int.Parse(Number);
    public int Row { get; set; } = 0;
    public int StartIndex { get; set; } = 0;
    public int EndIndex => StartIndex + Number.Length - 1;

    public static List<Part> Initialize(string[] schematic)
    {
        var parts = new List<Part> {};

        // Loop through the rows.
        for(var r = 0; r < schematic.Length; r++)        
        {
            var row = schematic[r];
            Part? part = null;

            // Loop through the columns.
            for(var c = 0; c < row.Length; c++)            
            {
                var ch = row[c];

                if(char.IsNumber(ch))
                {
                    // Are we continuing to evaluate an existing part or do we 
                    // need to create a new part?
                    part ??= new Part { Row = r, StartIndex = c };
                    part.Number += ch;
                }

                if(part is not null && !char.IsNumber(ch))
                {
                    parts.Add(part);
                    part = null;
                }
                else if(part is not null && c == row.Length - 1)
                {
                    parts.Add(part);
                    part = null;
                }
            }
        }

        return parts;
    }

    public bool ExistsAtPosition(int row, int column)
    {
        return Row == row && column >= StartIndex  && column <= EndIndex;
    }
}
