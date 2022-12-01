namespace AdventOfCode2022.Day1;

public static class First
{
    public static int Solve(string input)
    {
        var split = input.Split("\n\n");

        var biggest = 0;
        foreach (var elf in split)
        {
            var totaltCals = 0;
            foreach (var cals in elf.Split("\n"))
            {
                totaltCals += Int32.Parse(cals);
            }

            if (totaltCals > biggest)
            {
                biggest = totaltCals;
            }
        }
        
        return biggest;
    }
}