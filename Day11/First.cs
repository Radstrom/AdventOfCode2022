namespace Day11;

public static class First
{
    public static int Solve(string input)
    {
        var splitMonkeys = input.Split("\n\n");
        var monkeys = splitMonkeys.Select(x => new Monkey(x)).ToList();

        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    var afterInspect = monkey.Operate(item);
                    var afterBored = (ulong)Math.Floor(afterInspect / 3.0);
                    
                    monkeys
                        .ElementAt(afterBored % monkey.DivideBy == 0 ? 
                            monkey.IfTrueThrowTo : 
                            monkey.IfFalseThrowTo).Items.Add(afterBored);
                }

                monkey.Items = new List<ulong>();
            }
        }
        
        return monkeys.Select(x => x.TimesInspected).OrderByDescending(x => x).Take(2).Aggregate( ((i, i1) => i*i1));

    }

    public class Monkey
    {
        public int TimesInspected { get; set; } = 0;
        public List<ulong> Items { get; set; }
        public ulong DivideBy { get; set; }
        public int IfTrueThrowTo { get; set; }
        public int IfFalseThrowTo { get; set; }
    
        public string Operator { get; set; }
        public ulong OperateWith { get; set; }

        public ulong Operate(ulong old)
        {
            TimesInspected++;
            var operateWith = OperateWith != 0 ? OperateWith : old;
            return Operator switch
            {
                "*" => old * operateWith,
                "+" => old + operateWith,
                _ => throw new Exception()
            };
        }
    
        public Monkey(string input)
        {
            var split = input.Split("\n");

            Items = split
                .ElementAt(1)
                .Split(": ").ElementAt(1)
                .Split(", ").Select(ulong.Parse).ToList();
            DivideBy = ulong.Parse(split.ElementAt(3).Split(" by ").ElementAt(1));
            IfTrueThrowTo = int.Parse(split.ElementAt(4).Split(" monkey ").ElementAt(1));
            IfFalseThrowTo = int.Parse(split.ElementAt(5).Split(" monkey ").ElementAt(1));

            var operationInstruction = split
                .ElementAt(2)
                .Split(" = ").ElementAt(1);
            Operator = operationInstruction.Split(" ").ElementAt(1);
            OperateWith = ulong.TryParse(operationInstruction.Split(" ").ElementAt(2), out var result) ? result : 0;

        }
    }
}