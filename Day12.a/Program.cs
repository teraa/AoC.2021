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

Stack<string> visited = new();
visited.Push(start);

int result = Find(visited, start);

Console.WriteLine(result);

// ---

int Find(Stack<string> visited, string current)
{
    int result = 0;

    IEnumerable<string> validNeighborNodes = neighbors.Where(x => x.Item1 == current)
        .Select(x => x.Item2)
        .Except(visited);

    foreach (var node in validNeighborNodes)
    {
        if (node == end)
        {
            result++;
        }
        else if (node[0] is < 'a' or > 'z')
        {
            result += Find(visited, node);
        }
        else
        {
            visited.Push(node);
            result += Find(visited, node);
            visited.Pop();
        }
    }

    return result;
}
