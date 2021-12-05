List<Line> lines = new();
string? inputLine;

while ((inputLine = Console.ReadLine()) is not null)
{
    ReadOnlySpan<char> span = inputLine;

    int i = span.IndexOf(',');
    int x1 = int.Parse(span[..i]);

    span = span[(i + 1)..];

    i = span.IndexOf(' ');
    int y1 = int.Parse(span[..i]);

    span = span[(i + " -> ".Length)..];

    i = span.IndexOf(',');
    int x2 = int.Parse(span[..i]);

    span = span[(i + 1)..];

    int y2 = int.Parse(span);

    lines.Add(new(new(x1, y1), new(x2, y2)));
}

Dictionary<Point, int> hits = new();

foreach (var line in lines)
{
    int dx = line.End.X - line.Start.X;
    int dy = line.End.Y - line.Start.Y;
    int len;

    if (dx == 0)
        len = Math.Abs(dy);
    else if (dy == 0)
        len = Math.Abs(dx);
    else
        continue;

    int ix = Math.Sign(dx);
    int iy = Math.Sign(dy);

    for (int i = 0; i <= len; i++)
    {
        int x = line.Start.X + i * ix;
        int y = line.Start.Y + i * iy;
        Point point = new(x, y);
        hits[point] = hits.TryGetValue(point, out int value) ? value + 1 : 1;
    }
}

int result = hits.Count(x => x.Value > 1);

Console.WriteLine(result);

// ---

record struct Point(int X, int Y);
record struct Line(Point Start, Point End);
