using System;
using System.Collections.Generic;


public class Scanner_02
{
	List<Tuple<string, string>> listOfRounds = new List<Tuple<string, string>>();
	Parser parser = new Parser();
	public void GetListOfRounds(string data)
	{
		listOfRounds = parser.CreateListOfRoundsStr(data);
	}
	public int CalcScores(string data)
	{
		GetListOfRounds(data);
		Int32 scores = 0;
		foreach (var round in listOfRounds)
		{

			if (round.Item1 == "A")
			{
				if (round.Item2 == "X")
					scores += (3 + 0);
				else if (round.Item2 == "Y")
					scores += (1 + 3);
				else if (round.Item2 == "Z")
					scores += (2 + 6);
			}
			else if (round.Item1 == "B")
			{
				if (round.Item2 == "X")
					scores += (1 + 0);
				else if (round.Item2 == "Y")
					scores += (2 + 3);
				else if (round.Item2 == "Z")
					scores += (3 + 6);
			}
			else if (round.Item1 == "C")
			{
				if (round.Item2 == "X")
					scores += (2 + 0);
				else if (round.Item2 == "Y")
					scores += (3 + 3);
				else if (round.Item2 == "Z")
					scores += (1 + 6);
			}
		}
		return scores;
	}
}
