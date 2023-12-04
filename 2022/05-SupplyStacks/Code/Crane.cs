namespace Code;

public class Crane
{
    public static Dictionary<int, Stack> PerformMovementsWithPop(Dictionary<int, Stack> stacks, List<Movement> movements)
    {   
        foreach(var movement in movements)
        {
            var stackFrom = stacks[movement.FromStack];
            var toStack = stacks[movement.ToStack];

            var cratesToMove = stackFrom.Pop(movement.Quantity);
            cratesToMove.Reverse();
            toStack.Crates.AddRange(cratesToMove);
        }

        return stacks;
    }

    public static string GetTopCratesFromPopMovements(Dictionary<int, Stack> stacks, List<Movement> movements)
    {
        var results = PerformMovementsWithPop(stacks, movements);
        var crates = string.Join("", results.Select(c => c.Value.Crates.Last()));
        return crates;
    }

    public static Dictionary<int, Stack> PerformMovementsWithDequeue(Dictionary<int, Stack> stacks, List<Movement> movements)
    {   
        foreach(var movement in movements)
        {
            var stackFrom = stacks[movement.FromStack];
            var toStack = stacks[movement.ToStack];
            var cratesToMove = stackFrom.Pop(movement.Quantity);
            toStack.Crates.AddRange(cratesToMove);
        }

        return stacks;
    }  

    public static string GetTopCratesFromDequeueMovements(Dictionary<int, Stack> stacks, List<Movement> movements)
    {
        var results = PerformMovementsWithDequeue(stacks, movements);
        var crates = string.Join("", results.Select(c => c.Value.Crates.Last()));
        return crates;
    }

    public static void LogState(string message, Movement movement, Dictionary<int, Stack> stacks)
    {
        Console.WriteLine($"{message} for {movement.Value}...");
        foreach(var stack in stacks)
        {
            Console.WriteLine($"{stack.Key} : {string.Join(", ", stack.Value.Crates.Select(c => c))}");
        }
    }
}