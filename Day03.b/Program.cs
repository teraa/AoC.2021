using System;
using System.Collections.Generic;
using System.Diagnostics;

const int len = 12;

List<int> nums = new();
string? line;

while ((line = Console.ReadLine()) is not null)
    nums.Add(Convert.ToInt32(line, 2));

int a = Find(nums, (x, y) => x != y);
int b = Find(nums, (x, y) => x == y);

Console.WriteLine(a * b);

static int Find(IEnumerable<int> input, Func<int, int, bool> reduceCondition)
{
    List<int> subset = new(input);

    for (int i = len - 1; i >= 0 && subset.Count > 1; i--)
    {
        int ones = 0;

        for (int j = 0; j < subset.Count; j++)
            ones += (subset[j] >> i) & 1;

        int dominant = 2 * ones >= subset.Count ? 1 : 0;

        subset.RemoveAll(x => reduceCondition(((x >> i) & 1), dominant));
    }

    Debug.Assert(subset.Count == 1);

    return subset[0];
}
