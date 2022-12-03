namespace AdventOfCode2022.Day3;

public static class First
{
    public static int Solve(string input)
    {
        var rucksacks = input.Split("\n");

        return rucksacks.Select(x =>
        {
            var first = x.Substring(0, x.Length / 2);
            var second = x.Substring(x.Length / 2);

            var common = first.Intersect(second);

            return (Convert(common.First()));
        }).Sum();
    }

    public static int Convert(char a)
    {
        var asInt = (int) a;
        return asInt < 96 ? asInt -38 : asInt - 96;
    }
}