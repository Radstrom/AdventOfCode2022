namespace Day4;

public static class Second
{
    public static int Solve(string input)
    {
        var pairs = input.Split("\n");

        var total = 0;
        foreach (var pair in pairs)
        {
            var splitPair = pair.Split(",");
            var first = new Elf(splitPair.ElementAt(0));
            var second = new Elf(splitPair.ElementAt(1));

            if (first.IsIncluded(second) || second.IsIncluded(first))
            {
                total++;
            }
        }
        return total;
    }

    public static bool IsIncluded(this Elf first, Elf other)
    {
        if (first.Lower >= other.Lower && first.Lower <= other.Higher)
        {
            return true;
        }
        
        if (first.Higher >= other.Lower && first.Higher <= other.Higher)
        {
            return true;
        }

        return false;
    }

    public class Elf
    {
        public int Lower { get; set; }
        public int Higher { get; set; }
        public Elf(string input)
        {
            var splitInput = input.Split("-");
            Lower = int.Parse(splitInput.ElementAt(0));
            Higher = int.Parse(splitInput.ElementAt(1));
        }
    }
}