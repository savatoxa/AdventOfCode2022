using System;
using System.Collections.Generic;
using System.Linq;

public class Parser
{
	public string[] SplitStrByEmptyLines(string dataStr)
	{
		string[] dataStrArr = dataStr.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
		return dataStrArr;
	}
	public string[] SplitStrByLines(string dataStr)
	{
		return dataStr.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
	}
	public int[] SplitStrBySpaces(string dataStr)
	{
		var strArr = dataStr.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
		return Array.ConvertAll(strArr, int.Parse);
	}
	public string[] SplitStrBySpaces2(string dataStr)
	{
		return dataStr.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
	}
	public List<List<int>> CreateListOfListsOfInt(string dataStr)
	{
		List<List<int>> listOfListsOfNums = new List<List<int>>();
		string[] dataStrArr = SplitStrByEmptyLines(dataStr);
		foreach (var dataSubStr in dataStrArr)
		{
			string[] dataStrArr2 = SplitStrByLines(dataSubStr);
			List<int> numsList = new List<int>();
			foreach (var numStr in dataStrArr2)
			{
				numsList.Add(Convert.ToInt32(numStr));
			}
			listOfListsOfNums.Add(numsList);
		}
		return listOfListsOfNums;
	}
	public List<Tuple<string, string>> CreateListOfRoundsStr(string dataStr)
	{
		List<Tuple<string, string>> listOfRoundsStr = new List<Tuple<string, string>>();
		var roundsArrStr = SplitStrByLines(dataStr);
		foreach (var roundStr in roundsArrStr)
		{
			var round = Tuple.Create(roundStr.Split(' ')[0], roundStr.Split(' ')[1]);
			listOfRoundsStr.Add(round);
		}
		return listOfRoundsStr;
	}
	public List<string> CreateListRucksacksStr(string dataStr)
	{
		List<string> listRucksack = new List<string>();
		var rucksackArrStr = SplitStrByLines(dataStr);
		foreach (var rucksack in rucksackArrStr)
			listRucksack.Add(rucksack);
		return listRucksack;
	}
	public Tuple<Tuple<int, int>, Tuple<int, int>> GetLineClosingsInt(string[] lineClosingsStr)
	{
		var lineStartStrArr = lineClosingsStr[0].Split('-');
		var lineEndStrArr = lineClosingsStr[1].Split('-');
		var lineStartInt = Tuple.Create(Convert.ToInt32(lineStartStrArr[0]), Convert.ToInt32(lineStartStrArr[1]));
		var lineEndInt = Tuple.Create(Convert.ToInt32(lineEndStrArr[0]), Convert.ToInt32(lineEndStrArr[1]));
		return Tuple.Create(lineStartInt, lineEndInt);
	}
	public List<Tuple<Tuple<int, int>, Tuple<int, int>>> GetAllLinesClosings(string dataStr)
	{
		List<Tuple<Tuple<int, int>, Tuple<int, int>>> allLinesClosings = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
		var dataStrArr = SplitStrByLines(dataStr);
		foreach (var lineStr in dataStrArr)
		{
			var lineClosingsInt = GetLineClosingsInt(lineStr.Split(','));
			allLinesClosings.Add(lineClosingsInt);
		}
		return allLinesClosings;
	}
	public List<List<char>> TransposeMatrix(List<List<char>> matrix)
	{
		List<List<char>> transposedMatrix = new List<List<char>>();
		for (var i = 0; i < matrix[0].Count; i++)
		{
			List<char> col = new List<char>();
			for (var j = matrix.Count - 1; j >= 0; j--)
				col.Add(matrix[j][i]);
			transposedMatrix.Add(col);
		}
		return transposedMatrix;
	}
	public List<List<char>> CreateListStaks(string data)
	{
		List<List<char>> rows = new List<List<char>>();
		List<List<char>> cols = new List<List<char>>();
		var rowsStrArr = SplitStrByLines(SplitStrByEmptyLines(data)[0]);
		var numsIntArr = SplitStrBySpaces(rowsStrArr[rowsStrArr.Length - 1]);
		foreach (var rowStr in rowsStrArr)
		{
			List<char> row = new List<char>();
			for (int i = 1; i < numsIntArr.Count() * 4; i += 4)
				row.Add(rowStr[i]);
			rows.Add(row);
		}
		cols = TransposeMatrix(rows);
		foreach (var col in cols)
			while (col[col.Count - 1] == ' ')
				col.Remove(col[col.Count - 1]);

		return cols;
	}
	public List<int[]> CreateListMoves(string data)
	{
		List<int[]> moves = new List<int[]>();
		var movesStr = SplitStrByLines(SplitStrByEmptyLines(data)[1]);
		foreach (var str_ in movesStr)
			moves.Add(SplitStrBySpaces(str_.Replace("move ", "").Replace("from ", "").Replace("to ", "")));
		return moves;
	}
	public List<List<string>> CreateCommands(string data)
	{
		List<List<string>> commands = new List<List<string>>();
		var linesStr = SplitStrByLines(data);
		foreach (var lineStr in linesStr)
		{
			List<string> commandList = SplitStrBySpaces2(lineStr).ToList();
			commands.Add(commandList);
		}
		return commands;
	}
	public List<List<int>> CreateGrid(string data)
	{
		List<List<int>> grid = new List<List<int>>();
		var rowsList = SplitStrByLines(data).ToList();
		foreach (var rowStr in rowsList)
		{
			List<int> row = new List<int>();
			foreach (char num in rowStr)
				row.Add(Convert.ToInt16(num.ToString()));
			grid.Add(row);
		}
		return grid;
	}
	public List<Tuple<string, int>> CreateCommandsHead(string data)
	{
		List<Tuple<string, int>> commands = new List<Tuple<string, int>>();
		var linesStr = SplitStrByLines(data);
		foreach (var lineStr in linesStr)
		{
			List<string> commandList = SplitStrBySpaces2(lineStr).ToList();
			var command = Tuple.Create(commandList[0], Convert.ToInt32(commandList[1]));
			commands.Add(command);
		}
		return commands;
	}
	public void PrintMatrix(List<List<char>> matrix)
	{
		Console.WriteLine("");
		foreach (var row in matrix)
			Console.WriteLine("[{0}]", string.Join(", ", row));
	}
	public void PrintGrid(List<List<int>> grid)
	{
		foreach (var row in grid)
			Console.WriteLine("[{0}]", string.Join(", ", row));
	}
	public void PrintTuples(List<Tuple<string, int>> tuples)
	{
		tuples.ForEach(t => Console.WriteLine(t));
	}
}