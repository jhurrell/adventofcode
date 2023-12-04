namespace Code;

public class Symbol
{
    public int Row { get; set; } = 0;
    public int Column { get; set; } = 0;
    public char Value { get; set; } = default;

    public static List<Symbol> Initialize(string[] schematic)
    {
        var symbols = new List<Symbol> {};
        
        // Loop through the rows.
        for(var r = 0; r < schematic.Length; r++)        
        {
            var row = schematic[r];

            // Loop through the columns.
            for(var c = 0; c < row.Length; c++)            
            {
                var ch = row[c];
                if(!char.IsDigit(ch) && ch != '.')
                {
                    symbols.Add(new Symbol { Row = r, Column = c, Value = ch });
                }
            }          
        }              

        return symbols;
    }

    public static List<Part> GetAdjacentParts(List<Part> parts, int row, int column)
    {
        var adjacentParts = new List<Part> {};

        // Get Parts adjacent to the symbol in each of the cardinal directions.
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row - 1, column -1)));       // NW
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row - 1, column)));          // N
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row - 1, column + 1)));      // NE
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row, column - 1)));          // W
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row, column + 1)));          // E
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row + 1, column - 1)));      // SW
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row + 1, column)));          // S
        adjacentParts.AddRange(parts.Where(p => p.ExistsAtPosition(row + 1, column + 1)));      // SE

        // We could have duplicates so we will need to de-duplicate.
        return adjacentParts
            .GroupBy(elem=>elem.Id)
            .Select(group=>group.First())
            .ToList();
    }

    public static int GetAdjacentPartsSum(List<Symbol> symbols, List<Part> parts)
    {
        var adjacentParts = new List<Part> {};

        foreach(var symbol in symbols)
        {
            adjacentParts.AddRange(Symbol.GetAdjacentParts(parts, symbol.Row, symbol.Column));
        }

        return adjacentParts.Sum(p => p.Value);
    }

    public static List<Part> GetAdjacentGears(List<Part> parts, int row, int column)
    {
        var gears = GetAdjacentParts(parts, row, column);
        if(gears.Count == 2)
            return gears;
        else
            return new List<Part>{};
    }

    public static int GetAdjacentGearRatioSums(List<Symbol> symbols, List<Part> parts)
    {
        var adjacentGearRatioSums = 0;

        foreach(var symbol in symbols.Where(s => s.Value == '*'))
        {
            var adjacentGears = Symbol.GetAdjacentGears(parts, symbol.Row, symbol.Column);
            if(adjacentGears.Count == 2)
            {
                adjacentGearRatioSums += adjacentGears[0].Value * adjacentGears[1].Value;
            }
        }

        return adjacentGearRatioSums;
    }    
}
