using System;

int pos = 0, depth = 0;

string? line;
while ((line = Console.ReadLine()) is not null)
{
    var span = line.AsSpan();
    int x = int.Parse(span[(span.IndexOf(' ') + 1)..]);

    switch (span[0])
    {
        case 'd':
            depth += x;
            break;
        case 'u':
            depth -= x;
            break;
        default:
            pos += x;
            break;
    }
}

Console.WriteLine(pos * depth);
