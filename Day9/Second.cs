namespace Day9;

public static class Second
{
    public static int Solve(string input)
    {
        var instructions = input.Split("\n");
        var knots = new List<End>();
        for (var i = 0; i < 10; i++)
        {
            knots.Add(new End { X = 0, Y = 0});
        }
        var head = knots.First();
        var tailPositions = new List<End> { new () { X = 0, Y = 0 }};

        foreach (var instruction in instructions)
        {
            var direction = instruction.Split(" ").ElementAt(0);
            var steps = int.Parse(instruction.Split(" ").ElementAt(1));

            for (var stepsTaken = 0; stepsTaken < steps; stepsTaken++)
            {
                if (direction == "U")
                {
                    head.Y--;
                } else if (direction == "D")
                {
                    head.Y++;
                } else if (direction == "L")
                {
                    head.X--;
                } else if (direction == "R")
                {
                    head.X++;
                }

                for (var current = 1; current < knots.Count; current++)
                {
                    Move(knots.ElementAt(current-1),knots.ElementAt(current));
                }
                tailPositions.Add(new End() { X = knots.Last().X, Y = knots.Last().Y});
            }
        }
        
        return tailPositions
            .Distinct()
            .Count();
    }

    public static void Move(End prev, End current)
    {
        if (Math.Abs(prev.X - current.X) > 1 || Math.Abs(prev.Y - current.Y) > 1)
        {
            var newTail = new End() {X = current.X, Y = current.Y};
                    
            if (prev.Y - newTail.Y > 0)
            {
                newTail.Y++;
            } else if (prev.Y - newTail.Y < 0)
            {
                newTail.Y--;
            } 
                    
            if (prev.X - newTail.X > 0)
            {
                newTail.X++;
            } else if (prev.X - newTail.X < 0)
            {
                newTail.X--;
            }

            current.X = newTail.X;
            current.Y = newTail.Y;
        }
    }
    
    public class End : IEquatable<End>
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public bool Equals(End p)
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