const int mid = 59;
const int digits = 10;

int[] values = new int[digits];
int[] lengths = new int[digits];
int[] decoded = new int[digits];
int sum = 0;
string? line;

while ((line = Console.ReadLine()) is not null)
{
    Array.Fill(values, 0);
    Array.Fill(lengths, 0);
    Array.Fill(decoded, -1);

    ReadOnlySpan<char> span = line;

    var input = span[..(mid - 1)];

    for (int i = 0, j = 0; i < input.Length; i++)
    {
        if (input[i] is ' ')
        {
            j++;
        }
        else
        {
            values[j] |= 1 << (input[i] - 'a');
            lengths[j]++;
        }
    }

    // 1, 4, 7, 8 by length
    for (int i = 0; i < lengths.Length; i++)
    {
        int j = lengths[i] switch
        {
            2 => 1,
            3 => 7,
            4 => 4,
            7 => 8,
            _ => -1,
        };

        if (j != -1)
            decoded[j] = i;
    }

    Dictionary<int, int[]> byLength = lengths.Select((len, idx) => (len, idx))
        .GroupBy(x => x.len, x => x.idx)
        .ToDictionary(x => x.Key, x => x.ToArray());

    decoded[6] = byLength[6].First(x => GetWeight(values[x] & values[decoded[1]]) == 1);
    decoded[9] = byLength[6].First(x => (values[x] & values[decoded[4]]) == values[decoded[4]]);
    decoded[0] = byLength[6].First(x => x != decoded[6] && x != decoded[9]);

    decoded[3] = byLength[5].First(x => (values[x] & values[decoded[1]]) == values[decoded[1]]);
    decoded[2] = byLength[5].First(x => GetWeight(values[x] & values[decoded[4]]) == 2);
    decoded[5] = byLength[5].First(x => x != decoded[3] && x != decoded[2]);

    var output = span[(mid + 2)..];
    int[] outputSegments = new int[4];

    for (int i = 0, j = 0; i < output.Length; i++)
    {
        if (output[i] is ' ')
            j++;
        else
            outputSegments[j] |= 1 << (output[i] - 'a');
    }

    int result = 0;
    foreach (var segments in outputSegments)
    {
        int i = Array.IndexOf(values, segments);
        int j = Array.IndexOf(decoded, i);
        result = result * 10 + j;
    }

    sum += result;
}

Console.WriteLine(sum);

static int GetWeight(int value)
{
    int result = 0;

    for (int i = 0; i < digits; i++)
    {
        result += value & 1;
        value >>= 1;
    }

    return result;
}
