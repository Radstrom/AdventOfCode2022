namespace Da5;

public static class First
{
    public static string Solve(string input, int length)
    {
        var boxes = new List<Stack>();
        var setup = input.Split("\n\n").ElementAt(0).Split("\n");
        for (int i = 0; i < length; i++)
        {
            boxes.Add(new Stack { Index = i+1});
        }

        for (int i = setup.Length-2; i >= 0; i--)
        {
            var row = setup.ElementAt(i);
            for (var j = 1; j < length+1; j++)
            {
                var currentBox = boxes.Single(x => x.Index == j).Boxes;
                var currentChar = row.ElementAt(1 + (j - 1) * 4);
                if (currentChar != ' ')
                {
                    currentBox.Add(currentChar);
                }
            }
        }

        var moves = input.Split("\n\n").ElementAt(1).Split("\n");

        foreach (var move in moves)
        {
            var splitMove = move.Split(" ");
            var moveX = int.Parse(splitMove.ElementAt(1));
            var fromX = int.Parse(splitMove.ElementAt(3));
            var toX = int.Parse(splitMove.ElementAt(5));

            for (int i = 0; i < moveX; i++)
            {
                var removed = boxes.Single(x => x.Index == fromX).RemoveOne();
                boxes.Single(x => x.Index == toX).AddOne(removed);
            }
        }

        var result = "";
        foreach (var endBox in boxes)
        {
            result += endBox.FinalBox();
        }
        return result;
    }

    public class Stack
    {
        public List<char> Boxes { get; set; } = new List<char>();
        public int Index { get; set; } = 0;

        public char RemoveOne()
        {
            var toRemove = Boxes.ElementAt(Boxes.Count - 1);
            Boxes.RemoveAt(Boxes.Count-1);
            return toRemove;
        }

        public void AddOne(char toAdd)
        {
            Boxes.Add(toAdd);
        }

        public string FinalBox()
        {
            return Boxes.ElementAt(Boxes.Count - 1).ToString();
        }
    }
}