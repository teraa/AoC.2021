HashSet<(int, int)> processed = new();
int[] topSizes = new int[3];
List<string> input = new();

string? line;
while ((line = Console.ReadLine()) is not null)
    input.Add(line);


for (int i = 0; i < input.Count; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        int size = Process(i, j);
        var min = topSizes.Select((v, i) => (v, i)).Min();
        if (min.v < size)
            topSizes[min.i] = size;
    }
}

long prod = topSizes.Aggregate(1L, (a, v) => a * v);

Console.WriteLine(prod);

// ---

int Process(int i, int j)
{
    if (!processed.Add((i, j))
        || i < 0
        || i >= input.Count
        || j < 0
        || j >= input[i].Length
        || input[i][j] == '9')
        return 0;

    return 1
        // up
        + Process(i - 1, j)
        // down
        + Process(i + 1, j)
        // left
        + Process(i, j - 1)
        // right
        + Process(i, j + 1);
}
