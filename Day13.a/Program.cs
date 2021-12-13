List<(int x, int y)> points = new();
int i;
string? line;
ReadOnlySpan<char> span;

while ((line = Console.ReadLine()) is   { Length: > 0 })
{
    span = line;
    i = span.IndexOf(',');
    int x = int.Parse(span[..i]);
    int y = int.Parse(span[(i + 1)..]);
    points.Add((x, y));
}

i = "fold along ".Length;

span = Console.ReadLine();
char axis = span[i];
int value = int.Parse(span[(i + 2)..]);

Func<(int x, int y), bool> predicate;
Func<(int x, int y), (int x, int y)> projection;

if (axis == 'x')
{
    predicate = p => p.x > value;
    projection = p => p with { x = 2 * value - p.x };
}
else
{
    predicate = p => p.y > value;
    projection = p => p with { y = 2 * value - p.y };
}

var pointsToMove = points.Where(predicate).ToArray();
points.RemoveAll(p => predicate(p));
points.AddRange(pointsToMove.Select(projection));

int result = points.Distinct().Count();
Console.WriteLine(result);
