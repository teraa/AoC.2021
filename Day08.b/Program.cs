const int mid = 59;
const int digits = 10;

int[] values = new int[digits]; // read input values
int[] lens = new int[digits]; // lengths of each read value - number of segments
int[] decoded = new int[digits]; // elements represent indices of elements in values array
int sum = 0;
string? line;

while ((line = Console.ReadLine()) is not null)
{
    Array.Fill(values, 0); // Since we use |=
    Array.Fill(lens, 0); // Since we use ++
    Array.Fill(decoded, -1); // Not needed, only for debugging

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
            lens[j]++;
        }
    }

    // 1, 4, 7, 8 by length
    for (int i = 0; i < lens.Length; i++)
    {
        int j = lens[i] switch
        {
            2 => 1,
            3 => 7,
            4 => 4,
            7 => 8,
            _ => -1,
        };

        if (j != -1)
            decoded[j] = values[i];
    }

    int[] len5 = new int[3];
    int[] len6 = new int[3];

    for (int i = 0, i5 = 0, i6 = 0; i < lens.Length; i++)
    {
        switch (lens[i])
        {
            case 5: len5[i5++] = values[i]; break;
            case 6: len6[i6++] = values[i]; break;
        }
    }

    // HW(x) represents Hamming weight of x

    // length 6, HW(6 & 1) = 1
    decoded[6] = len6.First(x => GetWeight(x & decoded[1]) == 1);
    // length 6, 9 & 4 = 4
    decoded[9] = len6.First(x => (x & decoded[4]) == decoded[4]);
    // last remaining of length 6
    decoded[0] = len6.First(x => x != decoded[6] && x != decoded[9]);

    // length 5, 3 & 1 = 1
    decoded[3] = len5.First(x => (x & decoded[1]) == decoded[1]);
    // length 5, HW(2 & 4) = 2
    decoded[2] = len5.First(x => GetWeight(x & decoded[4]) == 2);
    // last remaining of length 5
    decoded[5] = len5.First(x => x != decoded[3] && x != decoded[2]);

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
    foreach (int segs in outputSegments)
    {
        int j = Array.IndexOf(decoded, segs);
        result = result * 10 + j;
    }

    sum += result;
}

Console.WriteLine(sum);

// Hamming weight
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
