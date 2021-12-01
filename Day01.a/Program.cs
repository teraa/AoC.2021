using System;

string? line;
int count = 0;
int? prev = null;

while ((line = Console.ReadLine()) is not null)
{
    var num = int.Parse(line);
    if (num > prev)
        count++;

    prev = num;
}

Console.WriteLine(count);
