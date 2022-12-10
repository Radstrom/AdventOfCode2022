namespace Day10;

public static class First
{
    public static int Solve(string input)
    {
        var instructions = input.Split("\n");
        var results = new List<int>() { 0 };

        var cyclesPassed = 0;
        var x = 1;
        foreach (var instruction in instructions)
        {
            var splitInstruction = instruction.Split(" ");
            var command = splitInstruction.ElementAt(0);

            if (command == "noop")
            {
                cyclesPassed++;
                results.Add(x);
            }

            var value = 0;
            if (command == "addx")
            {
                value = int.Parse(splitInstruction.ElementAt(1));

                results.Add(x);
                results.Add(x);
                
                cyclesPassed += 2;
                x += value;
            }

            if (cyclesPassed%20 == -1 || cyclesPassed % 20 == 0 || cyclesPassed % 20 == 1)
            {
                Console.WriteLine($"{cyclesPassed}  -  { x }  -  { value } - { x * cyclesPassed }");
            }

        }


        var result = new List<int>();
        for (int i = 20; i < results.Count; i += 40)
        {
            result.Add(results.ElementAt(i)*i);
        }

        return result.Sum();

        return 0;

    }

    public class DelayedInstruction
    {
        public string Command { get; set; }
        public int CyclesToExecute { get; set; }
    }
}