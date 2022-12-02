namespace AdventOfCode.Day2;

public static class Second
{
    public static int Solve(string input)
    {
        var rounds = input.Split("\n");

        return rounds.Select(x => x.Split(" ")).Select(y =>
        {
            var roundScore = 0;
            var option = "";
            if (y.ElementAt(1) == "X")
            {
                if (y.ElementAt(0) == "A") option = "Z";
                if (y.ElementAt(0) == "B") option = "X";
                if (y.ElementAt(0) == "C") option = "Y";
            };
            if (y.ElementAt(1) == "Y")
            {
                if (y.ElementAt(0) == "A") option = "X";
                if (y.ElementAt(0) == "B") option = "Y";
                if (y.ElementAt(0) == "C") option = "Z";
            };
            if (y.ElementAt(1) == "Z")
            {
                if (y.ElementAt(0) == "A") option = "Y";
                if (y.ElementAt(0) == "B") option = "Z";
                if (y.ElementAt(0) == "C") option = "X";
            };

            if (option == "X") roundScore += 1;
            if (option == "Y") roundScore += 2;
            if (option == "Z") roundScore += 3;
            
            roundScore += Decide(y.ElementAt(0), option);
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