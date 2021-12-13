List<Point> points = new();
int i;
string? line;

while ((line = Console.ReadLine()) is { Length: > 0 })
{
    ReadOnlySpan<char> span = line;
    i = span.IndexOf(',');
    int x = int.Parse(span[..i]);
    int y = int.Parse(span[(i + 1)..]);
    points.Add(new(x, y));
}

i = "fold along ".Length;
(int x, int y) max = (0, 0);

while ((line = Console.ReadLine()) is not null)
{
    ReadOnlySpan<char> span = line;
    char axis = span[i];
    int value = int.Parse(span[(i + 2)..]);

    Func<Point, bool> predicate;
    Func<Point, Point> projection;

    if (axis == 'x')
    {
        max.x = value;
        predicate = p => p.X > value;
        projection = p => p with { X = 2 * value - p.X };
    }
    else
    {
        max.y = value;
        predicate = p => p.Y > value;
        projection = p => p with { Y = 2 * value - p.Y };
    }

    var pointsToMove = points.Where(predicate).ToArray();
    points.RemoveAll(p => predicate(p));
    points.AddRange(pointsToMove.Select(projection));
}

for (int y = 0; y < max.y; y++)
{
    for (int x = 0; x < max.x; x++)
        Console.Write(points.Contains(new(x, y)) ? '█' : ' ');

    Console.WriteLine();
}

// ---

record struct Point(int X, int Y);
