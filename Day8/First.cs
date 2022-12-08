namespace Day8;

public static class First
{
    public static int Solve(string input)
    {
        var visibleTrees = new List<Coordinates>()
        {
            
        };

        var rows = input.Split("\n");
        
        // Find top down
        for (var x = 0; x < rows.ElementAt(0).Length; x++)
        {
            var highest = -1;
            for (var y = 0; y < rows.Length; y++)
            {
                var current = rows.ElementAt(y).ElementAt(x).ToInt();
                if (current > highest)
                {
                    visibleTrees.Add(new Coordinates(x, y));
                    highest = current;
                }
            }
        }
        
        // Find down up
        for (var x = 0; x < rows.ElementAt(0).Length; x++)
        {
            var highest = -1;
            for (var y = rows.Length-1; y > 0; y--)
            {
                var current = rows.ElementAt(y).ElementAt(x).ToInt();
                if (current > highest)
                {
                    visibleTrees.Add(new Coordinates(x, y));
                    highest = current;
                }
            }
        }
        
        // Find right left
        for (var y = 0; y < rows.Length; y++)
        {
            var highest = -1;
            for (var x = rows.ElementAt(0).Length-1; x >= 0; x--)
            {
                var current = rows.ElementAt(y).ElementAt(x).ToInt();
                if (current > highest)
                {
                    visibleTrees.Add(new Coordinates(x, y));
                    highest = current;
                }
            }
        }
        
        // Find left right
        for (var y = 0; y < rows.Length; y++)
        {
            var highest = -1;
            for (var x = 0; x < rows.ElementAt(0).Length; x++)
            {
                var current = rows.ElementAt(y).ElementAt(x).ToInt();
                if (current > highest)
                {
                    visibleTrees.Add(new Coordinates(x, y));
                    highest = current;
                }
            }
        }

        var distinct = visibleTrees.Distinct().OrderBy(x => x.X).ThenBy(x => x.Y);
        return visibleTrees
            .Distinct()
            .Count();
    }

    public static int ToInt(this char a)
    {
        return int.Parse(new string(new List<char>()
        {
            a
        }.ToArray()));
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