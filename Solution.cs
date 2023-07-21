public static class Solution
{
    private static Dictionary<(int, int), int>? _hash = null;

    public static int CountRepetitions(this char[][] input)
    {
        _hash = new();
        CountPositionRepetitions(input, 0, 0);
        return _hash.Values.Sum() / 6;
    }

    private static void CountPositionRepetitions(char[][] input, in int x, in int y)
    {
        int run = 0;
        var symbol = input[x][y];
        //down
        for (int i = x + 1; i <= x + 3; i++)
        {
            if (!input.HasIndex(i, y) || symbol != input[i][y])
            {
                run = 0;
                break;
            }
            run++;
        }
        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //up
        for (int i = x - 1; i >= x - 3; i--)
        {
            if (!input.HasIndex(i, y) || symbol != input[i][y])
            {
                run = 0;
                break;
            }
            run++;
        }
        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //left
        for (int j = y - 1; j >= y - 3; j--)
        {
            if (!input.HasIndex(x, j) || symbol != input[x][j])
            {
                run = 0;
                break;
            }
            run++;
        }
        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //right
        for (int j = y + 1; j <= y + 3; j++)
        {
            if (!input.HasIndex(x, j) || symbol != input[x][j])
            {
                run = 0;
                break;
            }
            run++;
        }
        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //down left
        int i2 = x;
        for (int j = y - 1; j >= y - 3; j--)
        {
            i2++;
            if (!input.HasIndex(i2, j) || symbol != input[i2][j])
            {
                run = 0;
                break;
            }
            run++;
        }

        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //up left
        i2 = x;
        for (int j = y - 1; j >= y - 3; j--)
        {
            i2--;
            if (!input.HasIndex(i2, j) || symbol != input[i2][j])
            {
                run = 0;
                break;
            }
            run++;
        }
        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //down right
        i2 = x;
        for (int j = y + 1; j <= y + 3; j++)
        {
            i2++;
            if (!input.HasIndex(i2, j) || symbol != input[i2][j])
            {
                run = 0;
                break;
            }
            run++;
        }
        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;
        run = 0;

        //up right
        i2 = x;
        for (int j = y + 1; j <= y + 3; j++)
        {
            i2--;
            if (!input.HasIndex(i2, j) || symbol != input[i2][j])
            {
                run = 0;
                break;
            }
            run++;
        }

        _hash![(x, y)] = _hash.GetValueOrDefault((x, y)) + run;

        if (input.HasIndex(x, y + 1))
            CountPositionRepetitions(input, x, y + 1);
        else if (input.HasIndex(x + 1, 0))
            CountPositionRepetitions(input, x + 1, 0);
    }

    private static bool HasIndex(this char[][] input, int i, int j)
    {
        if (i < 0 || j < 0)
            return false;
        return i < input.Length && j < input[i].Length;
    }
}