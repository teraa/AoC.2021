int count = 0;
string? line;

while ((line = Console.ReadLine()) is not null)
{
    var parts = line[(line.IndexOf('|') + 2)..].Split(' ');
    foreach (var part in parts)
        if (part.Length is 2 or 3 or 4 or 7)
            count++;
}

Console.WriteLine(count);
