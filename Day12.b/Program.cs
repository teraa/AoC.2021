const string start = "start";
const string end = "end";
const int maxLowVisits = 2;

HashSet<(string, string)> neighbors = new();

string? line;
while ((line = Console.ReadLine()) is not null)
{
    string[] parts = line.Split('-');
    neighbors.Add((parts[0], parts[1]));
    neighbors.Add((parts[1], parts[0]));
}

Stack<string> visited = new();
visited.Push(start);

int result = Find(visited, null);

Console.WriteLine(result);

// ---

int Find(Stack<string> visited, string? allowed)
{
    int result = 0;

    var excluded = visited.Where(x => IsLower(x) && (x != allowed || visited.Count(y => y == allowed) == maxLowVisits));

    string[] validNeighborNodes = neighbors.Where(x => x.Item1 == visited.Peek())
        .Select(x => x.Item2)
        .Except(excluded)
        .ToArray();

    foreach (var neighborNode in validNeighborNodes)
    {
        if (neighborNode != end)
        {
            visited.Push(neighborNode);

            result += Find(visited, allowed);

            if (allowed is null && IsLower(neighborNode))
                result += Find(visited, neighborNode);

            visited.Pop();
        }
        else if (allowed is null || visited.Count(x => x == allowed) == maxLowVisits)
        {
            result++;
        }
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
