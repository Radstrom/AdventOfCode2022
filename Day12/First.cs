namespace Day12;

public static class First
{
    public static int Solve(string input)
    {
        var instructions  = input.Split("\n");
        var squares = Setup(instructions);

        foreach (var square in squares)
        {
            square.AddNeighbors(squares);
        }

        var startSquare = squares
            .Single(x => x.Height == "S");
        return startSquare
            .FindPathToExit();
    }
    
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Height { get; set; }
        public List<Square> Neighbors { get; set; }
        public bool IsChecked { get; set; }
        public int? StepsToExit { get; set; }

        public void AddNeighbors(IList<Square> squares)
        {
            var toAdd = new List<Square>();
            toAdd.AddRange(squares
                .Where(x => x.X >= X-1 && x.X <= X+1 && x.Y == Y)
                .Where(x => IsValidNeighbors(this, x)));
            toAdd.AddRange(squares.Where(x => x.Y >= Y-1 && x.Y <= Y+1 && x.X == X && IsValidNeighbors(this, x)));
            toAdd.RemoveAll(x => x.X == X && x.Y == Y);
            Neighbors = toAdd;
        }

        public bool IsValidNeighbors(Square first, Square second)
        {
            if (first.Height is "S" or "E")
            {
                return true;
            }
            
            return first.Height.First() + 1 >= second.Height.First();
        }
        
        public int FindPathToExit()
        {
            if (Neighbors.FirstOrDefault(x => x.Height == "E") is not null)
            {
                return 1;
            }

            if (Neighbors.All(x => x.IsChecked))
            {
                return Neighbors.MinBy(x => x.StepsToExit)!.StepsToExit ?? 500;
            }

            IsChecked = true;

            var calculated = StepsToExit ?? Neighbors
                .Where(x => !x.IsChecked)
                .Select(x => x.FindPathToExit())
                .Min()+1;
            StepsToExit = calculated;
            return calculated;
        }
    }
    
    private static List<Square> Setup(string[] instructions)
    {
        var squares = new List<Square>();

        for (var row = 0; row < instructions.Length; row++)
        {
            for (var column = 0; column < instructions.ElementAt(row).Length; column++)
            {
                squares.Add(new Square()
                    {X = column, Y = row, Height = instructions.ElementAt(row).ElementAt(column).ToString()});
            }
        }

        return squares;
    }
}