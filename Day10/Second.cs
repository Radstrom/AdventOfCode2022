namespace Day10;

public static class Second
{
    public static int Solve(string input)
    {
        var instructions = input.Split("\n");
        var results = new List<int>();

        var x = 1;
        foreach (var instruction in instructions)
        {
            switch (instruction.Split(" ").ElementAt(0))
            {
                case "noop":
                    results.Add(x);
                    break;
                case "addx":
                {
                    results.Add(x);
                    results.Add(x);
                    x += int.Parse(instruction.Split(" ").ElementAt(1));
                    break;
                }
            }
        }
        
        var part2 = new List<string>();
        for (var i = 0; i < results.Count; i++)
        {
            if (results.ElementAt(i) <= i%40 + 1 && results.ElementAt(i) >= i%40 - 1)
            {
                part2.Add("#");
            }
            else
            {
                part2.Add(" ");
            }
        }

        var mergedPart2 = string.Join(string.Empty, part2);
        foreach (var line in mergedPart2.Chunk(40).Select(x => new string(x)))
        {
            Console.WriteLine(line);
        }
        return 0;
    }
}