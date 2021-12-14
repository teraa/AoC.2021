List<string> input = new();

string? line;
while ((line = Console.ReadLine()) is not null)
    input.Add(line);

int sum = 0;

for (int i = 0; i < input.Count; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        char c = input[i][j];
        int x, y;

        // up
        (x, y) = (i - 1, j);
        if (x >= 0 && input[x][y] <= c)
            continue;

        // down
        (x, y) = (i + 1, j);
        if (x < input.Count && input[x][y] <= c)
            continue;

        // left
        (x, y) = (i, j - 1);
        if (y >= 0 && input[x][y] <= c)
            continue;

        // right
        (x, y) = (i, j + 1);
        if (y < input[x].Length && input[x][y] <= c)
            continue;

        sum += input[i][j] - '0' + 1;
    }
}

Console.WriteLine(sum);
