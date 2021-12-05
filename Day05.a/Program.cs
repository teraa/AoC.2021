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
    (int minx, int maxx) = (line.Start.X, line.End.X);
    if (minx > maxx)
        (minx, maxx) = (maxx, minx);

    (int miny, int maxy) = (line.Start.Y, line.End.Y);
    if (miny > maxy)
        (miny, maxy) = (maxy, miny);

    if (minx == maxx)
    {
        for (int y = miny; y <= maxy; y++)
        {
            Point point = new(minx, y);
            Increment(point);
        }
    }

    if (miny == maxy)
    {
        for (int x = minx; x <= maxx; x++)
        {
            Point point = new(x, miny);
            Increment(point);
        }
    }
}

int result = hits.Count(x => x.Value > 1);

Console.WriteLine(result);

// ---

void Increment(Point point)
    => hits[point] = hits.TryGetValue(point, out int value) ? value + 1 : 1;

record struct Point(int X, int Y);
record struct Line(Point Start, Point End);
