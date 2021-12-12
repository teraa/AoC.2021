const string start = "start";
const string end = "end";

HashSet<(string, string)> neighbors = new();

string? line;
while ((line = Console.ReadLine()) is not null)
{
    string[] parts = line.Split('-');
    neighbors.Add((parts[0], parts[1]));
    neighbors.Add((parts[1], parts[0]));
}

int result = Find(new() { start });
Console.WriteLine(result);

// ---

int Find(List<string> visited)
{
    int result = 0;

    string[] validNeighborNodes = neighbors.Where(x => x.Item1 == visited[^1])
        .Select(x => x.Item2)
        .Except(visited.Where(x => IsLower(x)))
        .ToArray();

    foreach (var neighborNode in validNeighborNodes)
    {
        result += neighborNode == end
            ? 1
            : Find(new(visited) { neighborNode });
    }

    return result;
}

static bool IsLower(string value)
{
    for (int i = 0; i < value.Length; i++)
        if (value[i] is < 'a' or > 'z')
            return false;

    return true;
}
