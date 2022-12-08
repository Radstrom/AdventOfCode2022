namespace Day8;

public static class Second
{
    public static int Solve(string input)
    {
        var rows = input.Split("\n");

        var highestResult = 0;
        for (var x = 0; x < rows.ElementAt(0).Length-1; x++)
        {
            for (var y = 0; y < rows.Length-1; y++)
            {
                var topdown = FindTopDown(rows, x, y).Distinct().Count();
                var downUp = FindDownUp(rows, x, y).Distinct().Count();
                var leftRight = FindLeftRight(rows, x, y).Distinct().Count();
                var rightLeft = FindRightLeft(rows, x, y).Distinct().Count();

                var current = topdown * downUp * leftRight * rightLeft;
                if (highestResult < current)
                {
                    highestResult = current;
                }
            }
        }

        return highestResult;
    }

    private static List<Coordinates> FindDownUp(string[] rows, int vantageX, int vantageY)
    {
        var visibleTrees = new List<Coordinates>();
        // Find down up
        var highest = rows.ElementAt(vantageY).ElementAt(vantageX).ToInt();
        for (var y = vantageY-1; y >= 0; y--)
        {
            var current = rows.ElementAt(y).ElementAt(vantageX).ToInt();
            if (current < highest)
            {
                visibleTrees.Add(new Coordinates(vantageX, y));
            }
            else
            {
                visibleTrees.Add(new Coordinates(vantageX, y));
                break;
            }
        }

        return visibleTrees;
    }

    private static List<Coordinates> FindTopDown(string[] rows, int vantageX, int vantageY)
    {
        var visibleTrees = new List<Coordinates>();
        if (vantageY == rows.Length)
        {
            return visibleTrees;
        }
        // Find top down
        var highest = rows.ElementAt(vantageY).ElementAt(vantageX).ToInt();
        for (var y = vantageY+1; y < rows.Length; y++)
        {
            var current = rows.ElementAt(y).ElementAt(vantageX).ToInt();
            if (current < highest)
            {
                visibleTrees.Add(new Coordinates(vantageX, y));
            }
            else
            {
                visibleTrees.Add(new Coordinates(vantageX, y));
                break;
            }
        }

        return visibleTrees;
    }
    
    private static List<Coordinates> FindLeftRight(string[] rows, int vantageX, int vantageY)
    {
        var visibleTrees = new List<Coordinates>();
        var highest = rows.ElementAt(vantageY).ElementAt(vantageX).ToInt();
        for (var x = vantageX+1; x < rows.ElementAt(0).Length; x++)
        {
            var current = rows.ElementAt(vantageY).ElementAt(x).ToInt();
            if (current < highest)
            {
                visibleTrees.Add(new Coordinates(x, vantageY));
            }
            else
            {
                visibleTrees.Add(new Coordinates(x, vantageY));
                break;
            }
        }

        return visibleTrees;
    }
    
    private static List<Coordinates> FindRightLeft(string[] rows, int vantageX, int vantageY)
    {
        var visibleTrees = new List<Coordinates>();
        var highest = rows.ElementAt(vantageY).ElementAt(vantageX).ToInt();
        for (var x = vantageX-1; x >= 0; x--)
        {
            var current = rows.ElementAt(vantageY).ElementAt(x).ToInt();
            if (current < highest)
            {
                visibleTrees.Add(new Coordinates(x, vantageY));
            }
            else
            {
                visibleTrees.Add(new Coordinates(x, vantageY));
                break;
            }
        }

        return visibleTrees;
    }

    public class Coordinates : IEquatable<Coordinates>
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        
        public bool Equals(Coordinates p)
        {
            // Optimization for a common success case.
            if (object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != p.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (X == p.X) && (Y == p.Y);
        }
        
        public override int GetHashCode()
        {
            var hashFirstName = X.GetHashCode();
            var hashLastName = Y.GetHashCode();

            return hashFirstName ^ hashLastName;
        }
    }
}