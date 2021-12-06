const int spawn = 8;
const int reset = 6;
const int iterations = 256;

var timers = new long[spawn + 1];
var input = Console.ReadLine().AsSpan();

int idx;
while ((idx = input.IndexOf(',')) != -1)
{
    timers[int.Parse(input[..idx])]++;
    input = input[(idx + 1)..];
}

timers[int.Parse(input)]++;

for (int i = 0; i < iterations; i++)
{
    var tmp = timers[0];
    for (int j = 0; j < timers.Length - 1; j++)
        timers[j] = timers[j + 1];

    timers[spawn] = tmp;
    timers[reset] += tmp;
}

Console.WriteLine(timers.Sum());
