namespace Day6;

public static class First
{
    public static int Solve(string input)
    {
        const int desiredLength = 4;
        for (var i = 0; i < input.Length-desiredLength; i++)
        {
            if (input.Substring(i, desiredLength).Distinct().Count() == desiredLength)
            {
                return i+desiredLength;
            }
        }

        return 0;
    }
}