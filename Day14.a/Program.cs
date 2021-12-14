List<char> input = Console.ReadLine()!.Select(x => x).ToList();
Dictionary<(char, char), char> map = new();

Console.ReadLine();
string? line;
while ((line = Console.ReadLine()) is not null)
    map[(line[0], line[1])] = line[6];

for (int i = 0; i < 10; i++)
    for (int j = 0; j < input.Count - 1; j += 2)
        input.Insert(j + 1, map[(input[j], input[j + 1])]);

var results = input.GroupBy(x => x);
int max = results.Max(x => x.Count());
int min = results.Min(x => x.Count());

Console.WriteLine(max - min);
