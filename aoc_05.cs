using System;
using System.Collections.Generic;


public class Scanner_05
{
	List<List<char>> stacks = new List<List<char>>();
	List<int[]> moves = new List<int[]>();
	Parser parser = new Parser();

	public void GetStacks(string data)
	{
		stacks = parser.CreateListStaks(data);
	}

	public void GetMoves(string data)
	{
		moves = parser.CreateListMoves(data);
	}

	public void MoveOne(int[] move)
	{
		var idxMove = stacks[move[1] - 1].Count - 1;
		var charMove = stacks[move[1] - 1][idxMove];
		stacks[move[1] - 1].RemoveAt(idxMove);
		stacks[move[2] - 1].Add(charMove);
	}
	public void MoveSeveral(int[] move)
	{
		List<char> charsMove = new List<char>();
		var startIdxMove = stacks[move[1] - 1].Count - move[0];
		var endIdxMove = stacks[move[1] - 1].Count - 1;
		for (var i = startIdxMove; i <= endIdxMove; i++)
			charsMove.Add(stacks[move[1] - 1][i]);
		for (var i = endIdxMove; i >= startIdxMove; i--)
			stacks[move[1] - 1].RemoveAt(i);
		stacks[move[2] - 1].AddRange(charsMove);
	}

	public void MoveAll(string data)
	{
		GetMoves(data);
		GetStacks(data);
		foreach (var move in moves)
			MoveSeveral(move);
		parser.PrintMatrix(stacks);
	}
}
