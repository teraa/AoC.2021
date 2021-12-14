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

int result = Find(visited, start, null);

Console.WriteLine(result);

// ---

int Find(Stack<string> visited, string current, string? allowed)
{
    int result = 0;

    IEnumerable<string> excluded = visited.GroupBy(x => x)
        .Where(x => x.Key != allowed || x.Count() == maxLowVisits)
        .Select(x => x.Key);

    IEnumerable<string> validNeighborNodes = neighbors.Where(x => x.Item1 == current)
        .Select(x => x.Item2)
        .Except(excluded);

    foreach (string node in validNeighborNodes)
    {
        if (node != end)
        {
            if (node[0] is >= 'a' and <= 'z')
            {
                visited.Push(node);

                result += Find(visited, node, allowed);

                if (allowed is null)
                    result += Find(visited, node, node);

                visited.Pop();
            }
            else
            {
                result += Find(visited, node, allowed);
            }
        }
        else if (allowed is null || visited.Count(x => x == allowed) == maxLowVisits)
        {
            result++;
        }
    }

    return result;
}
