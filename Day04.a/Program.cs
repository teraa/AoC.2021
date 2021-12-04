using System;
using System.Collections.Generic;
using System.Linq;

const int size = 5;

string? line = Console.ReadLine()!;
List<int> ns = new();
int n = 0;

for (int i = 0; i < line.Length; i++)
{
    if (line[i] is ',')
    {
        ns.Add(n);
        n = 0;
    }
    else
    {
        n = n * 10 + line[i] - '0';
    }
}
ns.Add(n);

Span<int> picks = ns.ToArray();
List<int[][]> boards = new();

while ((line = Console.ReadLine()) is not null)
{
    int[][] board = new int[size][];
    for (int i = 0; i < size; i++)
    {
        board[i] = new int[size];
        line = Console.ReadLine()!;

        for (int j = 0; j < size; j++)
            board[i][j] = ((line[j * 3] == ' ') ? 0 : (line[j * 3] - '0')) * 10
                + (line[j * 3 + 1] - '0');
    }

    boards.Add(board);
}

for (int i = 0; i < picks.Length; i++)
{
    var picked = picks[..(i + 1)];

    for (int j = 0; j < boards.Count; j++)
    {
        if ((IsWinner(boards[j], picked)))
        {
            int score = GetScore(boards[j], picked);
            Console.WriteLine(score);
            return;
        }
    }
}

static bool IsWinner(int[][] board, ReadOnlySpan<int> picked)
{
    for (int i = 0, j; i < size; i++)
    {
        for (j = 0; j < size && picked.Contains(board[i][j]); j++)
        { }

        if (j == size)
            return true;
    }

    for (int i = 0, j; i < size; i++)
    {
        for (j = 0; j < size && picked.Contains(board[j][i]); j++)
        { }

        if (j == size)
            return true;
    }

    return false;
}

static int GetScore(int[][] board, ReadOnlySpan<int> picked)
{
    int sum = 0;

    for (int i = 0; i < board.Length; i++)
        for (int j = 0; j < board[i].Length; j++)
            if (!picked.Contains(board[i][j]))
                sum += board[i][j];

    return sum * picked[^1];
}
