using System;

const int offset = 3;

int count = 0;
int i = 0;
int[] arr = new int[offset];
string? line;
while ((line = Console.ReadLine()) is not null)
{
    int n = int.Parse(line);
    ref int p = ref arr[(i + offset) % offset];

    if (n > p)
        count++;

    p = n;
    i++;
}

count -= offset;

Console.WriteLine(count);
