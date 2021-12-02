using System;

const int offset = 3;

int count = -offset;
int[] arr = new int[offset];
int i = 0;
string? line;

while ((line = Console.ReadLine()) is not null)
{
    int n = int.Parse(line);
    ref int p = ref arr[i % offset];

    if (n > p)
        count++;

    p = n;
    i++;
}

Console.WriteLine(count);
