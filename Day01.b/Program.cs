using System;
using System.Collections.Generic;

const int offset = 3;

List<int> n = new();
string? line;
while ((line = Console.ReadLine()) is not null)
    n.Add(int.Parse(line));

int count = 0;
for (int i = offset; i < n.Count; i++)
    if (n[i - offset] < n[i])
        count++;

Console.WriteLine(count);
