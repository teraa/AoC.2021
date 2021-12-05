string? line;
Dictionary<Point, int> hits = new();

while ((line = Console.ReadLine()) is not null)
{
    ReadOnlySpan<char> span = line;

    int idx = span.IndexOf(',');
    int x1 = int.Parse(span[..idx]);

    span = span[(idx + 1)..];

    idx = span.IndexOf(' ');
    int y1 = int.Parse(span[..idx]);

    span = span[(idx + " -> ".Length)..];

    idx = span.IndexOf(',');
    int x2 = int.Parse(span[..idx]);

    span = span[(idx + 1)..];

    int y2 = int.Parse(span);


    int dx = x2 - x1;
    int dy = y2 - y1;

    int d;
    if (dx == 0)
        d = Math.Abs(dy);
    else if (dy == 0)
        d = Math.Abs(dx);
    else
        continue;

    int ix = Math.Sign(dx);
    int iy = Math.Sign(dy);

    for (int i = 0, x = x1, y = y1; i <= d; i++, x += ix, y += iy)
    {
        Point point = new(x, y);
        hits[point] = hits.TryGetValue(point, out int value) ? value + 1 : 1;
    }
}

int result = hits.Count(x => x.Value > 1);

Console.WriteLine(result);


record struct Point(int X, int Y);
