Dictionary<char, (char c, int p)> pairs = new()
{
    ['('] = (')', 1),
    ['['] = (']', 2),
    ['{'] = ('}', 3),
    ['<'] = ('>', 4),
};
List<long> scores = new();
Stack<char> stack = new();

string? line;
while ((line = Console.ReadLine()) is not null)
{
    stack.Clear();

    for (int i = 0; i < line.Length; i++)
    {
        if (pairs.ContainsKey(line[i]))
            stack.Push(line[i]);
        else if (pairs[stack.Pop()].c != line[i])
            break;

        if (i == line.Length - 1)
            scores.Add(stack.Aggregate(0L, (a, v) => a * 5 + pairs[v].p));
    }
}

long result = scores.OrderBy(x => x).ElementAt(scores.Count / 2);

Console.WriteLine(result);
