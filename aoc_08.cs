using System.Collections.Generic;

public class Scanner_08
{
    List<List<int>> grid = new List<List<int>>();
    Parser parser = new Parser();
    public void GetGrid(string data)
    {
        grid = parser.CreateGrid(data);
    }
    public int IsVisibleRight(int row, int col)
    {
        for (int i = col; i < grid[row].Count - 1; i++)
        {
            if (grid[row][col] <= grid[row][i + 1])
            {
                return i + 1 - col;
            }
        }
        return grid[row].Count - col - 1;
    }
    public int IsVisibleTop(int row, int col)
    {
        for (int i = row; i >= 1; i--)
            if (grid[row][col] <= grid[i - 1][col])
                return row - i + 1;
        return row;
    }
    public int IsVisibleLeft(int row, int col)
    {
        for (int i = col; i >= 1; i--)
            if (grid[row][col] <= grid[row][i - 1])
                return col - i + 1;
        return col;
    }
    public int IsVisibleDown(int row, int col)
    {
        for (int i = row; i < grid.Count - 1; i++)
            if (grid[row][col] <= grid[i + 1][col])
                return i - row + 1;
        return grid.Count - row - 1;
    }
    public int CountVisibleScores(int row, int col)
    {
        return IsVisibleRight(row, col) * IsVisibleTop(row, col) * IsVisibleLeft(row, col) * IsVisibleDown(row, col);
    }
    public int CountAllVisibleScores(string data)
    {
        GetGrid(data);
        List<int> scores = new List<int>();
        for (int row = 1; row < grid.Count - 1; row++)
            for (int col = 1; col < grid[row].Count - 1; col++)
                scores.Add(CountVisibleScores(row, col));
        scores.Sort();
        return scores[scores.Count - 1];
    }
}
