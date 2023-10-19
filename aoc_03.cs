using System;
using System.Collections.Generic;
using System.Linq;


public class Scanner_03
{
	List<string> listOfRucksacks = new List<string>();
	List<HashSet<char>> commonItems = new List<HashSet<char>>();
	Dictionary<char, int> commonItemsValue = new Dictionary<char, int> {{'a',1 }, {'b',2},{'c',3},{'d',4},{'e',5},{'f',6},
		{'g',7},{'h',8},{'i',9},{'j',10},{'k',11},{'l',12},{'m',13},{'n',14},{'o',15},{'p',16},{'q',17},{'r',18},{'s',19},
		{'t',20},{'u',21},{'v',22},{'w',23},{'x',24},{'y',25},{'z',26},{'A',27}, {'B',28},{'C',29},{'D',30},{'E',31},{'F',32},
		{'G',33},{'H',34},{'I',35},{'J',36},{'K',37},{'L',38},{'M',39},{'N',40},{'O',41},{'P',42},{'Q',43},{'R',44},{'S',45},
		{'T',46},{'U',47},{'V',48},{'W',49},{'X',50},{'Y',51},{'Z',52}};
	Parser parser = new Parser();
	public void GetListOfRucksacks(string data)
	{
		listOfRucksacks = parser.CreateListRucksacksStr(data);
	}
	public void GetListOfCommonItems(string data)
	{
		GetListOfRucksacks(data);
		for (var i = 0; i <= listOfRucksacks.Count - 3; i += 3)
		{
			HashSet<char> commonLetter = new HashSet<char>();
			foreach (var badge in listOfRucksacks[i])
			{
				if (listOfRucksacks[i + 1].Contains(badge) && listOfRucksacks[i + 2].Contains(badge))
					commonLetter.Add(badge);
			}
			commonItems.Add(commonLetter);
		}
	}
	public int CalcScores(string data)
	{
		GetListOfCommonItems(data);
		Int32 scores = 0;
		foreach (var item in commonItems)
		{
			foreach (var letter in item)
				scores += commonItemsValue[letter];
		}
		return scores;
	}
}
