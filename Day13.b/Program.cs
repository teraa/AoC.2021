List<(int x, int y)> points = new();
int i;
string? line;

while ((line = Console.ReadLine()) is { Length: > 0 })
{
    ReadOnlySpan<char> span = line;
    i = span.IndexOf(',');
    int x = int.Parse(span[..i]);
    int y = int.Parse(span[(i + 1)..]);
    points.Add((x, y));
}

i = "fold along ".Length;
(int x, int y) max = (0, 0);

while ((line = Console.ReadLine()) is not null)
{
    ReadOnlySpan<char> span = line;
    char axis = span[i];
    int value = int.Parse(span[(i + 2)..]);

    Func<(int x, int y), bool> predicate;
    Func<(int x, int y), (int x, int y)> projection;

    if (axis == 'x')
    {
        max.x = value;
        predicate = p => p.x > value;
        projection = p => p with { x = 2 * value - p.x };
    }
    else
    {
        max.y = value;
        predicate = p => p.y > value;
        projection = p => p with { y = 2 * value - p.y };
    }

    var pointsToMove = points.Where(predicate).ToArray();
    points.RemoveAll(p => predicate(p));
    points.AddRange(pointsToMove.Select(projection));
}

for (int y = 0; y < max.y; y++)
{
    for (int x = 0; x < max.x; x++)
        Console.Write(points.Contains((x, y)) ? '█' : ' ');

    Console.WriteLine();
}
