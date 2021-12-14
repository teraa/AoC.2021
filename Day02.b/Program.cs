int pos = 0, depth = 0, aim = 0;
string? line;

while ((line = Console.ReadLine()) is not null)
{
    var span = line.AsSpan();
    int x = int.Parse(span[(span.IndexOf(' ') + 1)..]);

    switch (span[0])
    {
        case 'd':
            aim += x;
            break;
        case 'u':
            aim -= x;
            break;
        default:
            pos += x;
            depth += aim * x;
            break;
    }
}

Console.WriteLine(pos * depth);
