using System;

const int len = 12;

int[] ones = new int[len];
int n = 0;
string? line;

while ((line = Console.ReadLine()) is not null)
{
    for (int i = 0; i < len; i++)
        ones[i] += line[i] - '0';

    n++;
}

int gamma = 0;
int epsilon = 0;

for (int i = 0; i < len; i++)
{
    int bit = 1 << (len - i - 1);

    if (2 * ones[i] >= n)
        gamma |= bit;
    else
        epsilon |= bit;
}

Console.WriteLine(gamma * epsilon);
