using System;
using System.Collections.Generic;

public class Scanner_01
{
	List<List<int>> allElvesCals = new List<List<int>>();
	List<int> eachElveCals = new List<int>();
	Parser parser = new Parser();
	public void GetAllElvesCals(string dataStr)
	{
		allElvesCals = parser.CreateListOfListsOfInt(dataStr);
	}

	public void GetEachElveCals(string dataStr)
	{
		GetAllElvesCals(dataStr);
		foreach (var elveCals in allElvesCals)
		{
			int sumOfElveCals = 0;
			foreach (var elveCal in elveCals)
			{
				sumOfElveCals += elveCal;
			}
			eachElveCals.Add(sumOfElveCals);
		}
	}

	public int FindMaxElve(string dataStr)
	{
		GetEachElveCals(dataStr);
		var maxCal0 = eachElveCals[0];
		var maxCal1 = eachElveCals[0];
		var maxCal2 = eachElveCals[0];
		for (var i = 0; i < eachElveCals.Count; i++)
		{
			if (eachElveCals[i] > maxCal0)
			{
				maxCal2 = maxCal1;
				maxCal1 = maxCal0;
				maxCal0 = eachElveCals[i];
			}
			else if (eachElveCals[i] > maxCal1)
			{
				maxCal2 = maxCal1;
				maxCal1 = eachElveCals[i];
			}
			else if (eachElveCals[i] > maxCal2)
			{
				maxCal2 = eachElveCals[i];
			}
		}
		return maxCal0 + maxCal1 + maxCal2;
	}
}