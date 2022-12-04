namespace AdventOfCode.Day2;

public static class First
{
    public static int Solve(string input)
    {
        var rounds = input.Split("\n");

        return rounds.Select(x => x.Split(" ")).Select(y =>
        {
            var roundScore = 0;
            if (y.ElementAt(1) == "X") roundScore += 1;
            if (y.ElementAt(1) == "Y") roundScore += 2;
            if (y.ElementAt(1) == "Z") roundScore += 3;

            roundScore += Decide(y.ElementAt(0), y.ElementAt(1));
            return roundScore;
        }).Sum();
    }

    private static int Decide(string a, string b)
    {
        if ((a == "A" & b == "X") || (a == "B" && b == "Y") || (a == "C" && b == "Z"))
        {
            return 3;
        }
        
        if (a == "A" && b != "Y")
        {
            return 0;
        }
        
        if (a == "B" && b != "Z")
        {
            return 0;
        }
        
        if (a == "C" && b != "X")
        {
            return 0;
        }

        return 6;
    }
}