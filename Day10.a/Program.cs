Dictionary<char, char> pairs = new()
{
    ['('] = ')',
    ['['] = ']',
    ['{'] = '}',
    ['<'] = '>',
};
Stack<char> stack = new();
long score = 0;

string? line;
while ((line = Console.ReadLine()) is not null)
{
    stack.Clear();
    for (int i = 0; i < line.Length; i++)
    {
        if (pairs.ContainsKey(line[i]))
        {
            stack.Push(line[i]);
        }
        else if (pairs[stack.Pop()] != line[i])
        {
            score += line[i] switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => throw new ArgumentException(),
            };
            break;
        }
    }
}

Console.WriteLine(score);
