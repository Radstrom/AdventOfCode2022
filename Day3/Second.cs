namespace AdventOfCode2022.Day3;

public static class Second
{
    public static int Solve(string input)
    {
        var rucksacks = input.Split("\n");

        var total = 0;
        for (var i = 0; i < rucksacks.Length; i+=3)
        {
            total += new List<string>()
            {
                rucksacks[i],
                rucksacks[i + 1],
                rucksacks[i + 2]
            }.Aggregate((common, next) => new string(common.Intersect(next).ToArray())).First().Convert();
        }

        return total;
    }

    public static int Convert(this char a)
    {
        var asInt = (int) a;
        return asInt < 96 ? asInt -38 : asInt - 96;
    }
}