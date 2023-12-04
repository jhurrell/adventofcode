namespace Code;

public class Stack
{
    public int Number { get; set; } = 0;
    public List<char> Crates { get; set; } = new();

    public static Dictionary<int, Stack> Initialize(string[] puzzle)
    {
        // There will be columns of square-bracket-wrapper characters and at the 
        // bottom of each column will be the number of stack. We need to parse
        // these first. Consider the input to be aragged array.

        // First, let's get a count of the number of stacks we will be working with.
        // Let's examine each line until we get to the line that has numbers. Once
        // we reach it, we will create a new CrateStack for each number and return
        // it as a dictionary.
        for(var i = 0; i < puzzle.Length; i++)
        {
            var trimmedLine = puzzle[i].Trim().Split("  ").ToList();

            if(trimmedLine[0] == "1")
            {
                return trimmedLine
                    .Select(s => Initialize(int.Parse(s), puzzle))
                    .ToDictionary(s => s.Number);
            }
        }

        return new();
    }

    public static Stack Initialize(int stackNumber, string[] puzzle)
    {
        // We need to retrieve all the crates associated with the stack
        // and add them to the stack.
        var crates = new List<char>{};
        for(int i = 0; i < puzzle.Length; i++)
        {
            // Calculate the index we need examine for the stack.
            var col = 1 + ((stackNumber - 1) * 4);

            // Get the character on the line at the column and test to see if we
            // need to treat it as a crate of if we are at the end of the list.
            var ch = puzzle[i][col];
            if(char.IsAsciiLetter(ch))
            {
                crates.Add(ch);
            }
            else if(char.IsNumber(ch))
            {
                break;
            }
        }

        crates.Reverse();
        return new Stack
        {
            Number = stackNumber,
            Crates = crates,
        };
    }

    public List<char> Pop(int quantity)
    {
        var results = Crates.TakeLast(quantity).ToList();
        Crates.RemoveRange(Crates.Count - quantity, quantity);
        return results;
    }
}
