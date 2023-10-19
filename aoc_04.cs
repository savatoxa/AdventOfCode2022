using System;
using System.Collections.Generic;


public class Scanner_04
{
	List<Tuple<Tuple<int, int>, Tuple<int, int>>> listOfSections = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
	Parser parser = new Parser();
	public void GetListOfSections(string data)
	{
		listOfSections = parser.GetAllLinesClosings(data);
	}
	public int CalculateNestedSections(string data)
	{
		int nestedPairs = 0;
		GetListOfSections(data);
		foreach (var pair in listOfSections)
		{
			var section1 = pair.Item1;
			var section2 = pair.Item2;
			if (section1.Item1 >= section2.Item1 && section1.Item2 <= section2.Item2)
				nestedPairs++;
			else if (section2.Item1 >= section1.Item1 && section2.Item2 <= section1.Item2)
				nestedPairs++;
		}
		return nestedPairs;
	}
	public int CalculateOverlapingSections(string data)
	{
		int overlapingSections = 0;
		GetListOfSections(data);
		foreach (var pair in listOfSections)
		{
			var section1 = pair.Item1;
			var section2 = pair.Item2;
			if (section1.Item1 <= section2.Item2 && section1.Item2 >= section2.Item2)
				overlapingSections++;
			else if (section2.Item1 <= section1.Item2 && section2.Item2 >= section1.Item2)
				overlapingSections++;
		}
		return overlapingSections;
	}
}
