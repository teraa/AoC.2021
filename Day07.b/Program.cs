ReadOnlySpan<char> input = Console.ReadLine();
List<int> nums = new();

int idx;
while ((idx = input.IndexOf(',')) != -1)
{
    nums.Add(int.Parse(input[..idx]));
    input = input[(idx + 1)..];
}
nums.Add(int.Parse(input));

int max = nums.Max();
int cost = int.MaxValue;
for (int i = max; i >= 0; i--)
{
    int c = nums.Sum(x =>
    {
        int n = Math.Abs(x - i);
        return n * (n + 1) / 2;
    });
    if (cost > c)
        cost = c;
}

Console.WriteLine(cost);
