namespace AdventOfCode2022.Day1;

public static class Second
{
    public static int Solve(string input)
    {
        var split = input.Split("\n\n");

        var elfs = split
            .Select(elf => elf.Split("\n")
                .Select(int.Parse)
                .Aggregate((sum, next) => sum += next))
            .OrderByDescending(x => x)
            .ToList();
        
        return elfs
            .Take(3)
            .Sum();
    }
}