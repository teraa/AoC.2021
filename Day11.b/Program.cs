const int size = 10;

int[][] arr = new int[size][];
int step = 0;
HashSet<(int i, int j)> flashed = new();

for (int i = 0; i < arr.Length; i++)
    arr[i] = Console.ReadLine()!.Select(x => x - '0').ToArray();

do
{
    flashed.Clear();

    for (int i = 0; i < arr.Length; i++)
        for (int j = 0; j < arr[i].Length; j++)
            Update(i, j);

    foreach (var point in flashed)
        arr[point.i][point.j] = 0;

    step++;
} while (flashed.Count != size * size);

Console.WriteLine(step);

// ---

void Update(int i, int j)
{
    if (++arr[i][j] >= 10 && flashed.Add((i, j)))
        for (int io = Math.Max(i - 1, 0); io <= i + 1 && io < arr.Length; io++)
            for (int jo = Math.Max(j - 1, 0); jo <= j + 1 && jo < arr[io].Length; jo++)
                if (io != i || jo != j)
                    Update(io, jo);
}
