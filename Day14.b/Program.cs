const int steps = 40;

string input = Console.ReadLine()!;
Dictionary<Pair, char> map = new();
Dictionary<Pair, long> counts = new();

for (int i = 0; i < input.Length - 1 ; i++)
{
    Pair pair = new(input[i], input[i + 1]);
    counts[pair] = counts.GetValueOrDefault(pair) + 1;
}

Console.ReadLine();
string? line;
while ((line = Console.ReadLine()) is not null)
{
    Pair pair = new(line[0], line[1]);
    map[pair] = line[6];
}

for (int i = 0; i < steps; i++)
{
    var previous = counts;
    counts = new();

    foreach (var (pair, count) in previous)
    {
        char c = map[pair];
        Pair p1 = new(pair.Left, c);
        Pair p2 = new(c, pair.Right);

        counts[p1] = counts.GetValueOrDefault(p1) + count;
        counts[p2] = counts.GetValueOrDefault(p2) + count;
    }
}

Dictionary<char, long> charCounts = counts.GroupBy(x => x.Key.Left)
    .ToDictionary(x => x.Key, x => x.Select(x => x.Value).Sum());

charCounts[input[^1]]++;

long max = charCounts.Max(x => x.Value);
long min = charCounts.Min(x => x.Value);
long result = max - min;

Console.WriteLine(result);

// ---

readonly record struct Pair(char Left, char Right);
