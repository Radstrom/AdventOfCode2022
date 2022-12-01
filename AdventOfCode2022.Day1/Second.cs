namespace AdventOfCode2022.Day1;

public static class Second
{
    public static int Solve(string input)
    {
        var split = input.Split("\n\n");

        var elfs = new List<int>();
        foreach (var elf in split)
        {
            var totaltCals = 0;
            foreach (var cals in elf.Split("\n"))
            {
                totaltCals += Int32.Parse(cals);
            }
            elfs.Add(totaltCals);
        }
        elfs = elfs.OrderByDescending(x => x).ToList();
        return elfs.ElementAt(0) + elfs.ElementAt(1) + elfs.ElementAt(2);
    }
}