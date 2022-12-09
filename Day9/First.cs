namespace Day9;

public static class First
{
    public static int Solve(string input)
    {
        var instructions = input.Split("\n");
        var head = new End() { X = 0, Y = 0};
        var tail = new List<End>() { new End() { X = 0, Y = 0 }};

        foreach (var instruction in instructions)
        {
            // parsa instruction
            var direction = instruction.Split(" ").ElementAt(0);
            var steps = int.Parse(instruction.Split(" ").ElementAt(1));

            for (var stepsTaken = 0; stepsTaken < steps; stepsTaken++)
            {
                // Flytta head
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
                
                // Försvann head mer än två bort?
                if (Math.Abs(head.X - tail.Last().X) > 1 || Math.Abs(head.Y - tail.Last().Y) > 1)
                {
                    // Skapa ny tail på vettigt ställe. tail.Last();
                    var newTail = new End() {X = tail.Last().X, Y = tail.Last().Y};
                    
                    if (head.Y - newTail.Y > 0)
                    {
                        newTail.Y++;
                    } else if (head.Y - newTail.Y < 0)
                    {
                        newTail.Y--;
                    } 
                    
                    if (head.X - newTail.X > 0)
                    {
                        newTail.X++;
                    } else if (head.X - newTail.X < 0)
                    {
                        newTail.X--;
                    } 
                    tail.Add(newTail);
                }
            }
        }
        
        return tail
            .Distinct()
            .Count();
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