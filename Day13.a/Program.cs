List<Point> points = new();
int i;
string? line;
ReadOnlySpan<char> span;

while ((line = Console.ReadLine()) is { Length: > 0 })
{
    span = line;
    i = span.IndexOf(',');
    int x = int.Parse(span[..i]);
    int y = int.Parse(span[(i + 1)..]);
    points.Add(new(x, y));
}

i = "fold along ".Length;

span = Console.ReadLine();
char axis = span[i];
int value = int.Parse(span[(i + 2)..]);

Func<Point, bool> predicate;
Func<Point, Point> projection;

if (axis == 'x')
{
    predicate = p => p.X > value;
    projection = p => p with { X = 2 * value - p.X };
}
else
{
    predicate = p => p.Y > value;
    projection = p => p with { Y = 2 * value - p.Y };
}

var pointsToMove = points.Where(predicate).ToArray();
points.RemoveAll(p => predicate(p));
points.AddRange(pointsToMove.Select(projection));

int result = points.Distinct().Count();
Console.WriteLine(result);

// ---

record struct Point(int X, int Y);
