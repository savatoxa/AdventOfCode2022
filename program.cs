using System;
using System.IO;

public static class DirectoriesMethods
{
	public static string DirUp(string dirName, int depth)
	{
		for (var i = dirName.Length - 1; i > 0; i--)
		{
			if (dirName[i].ToString() == "\\")
			{
				var dirParentName = dirName.Substring(0, i);
				depth--;
				if (depth == 0)
					return dirParentName;
				else
					return DirUp(dirParentName, depth);
			}
		}
		return dirName.Substring(0,2);
	}
}

class Program
{
	static void Main(string[] args)
	{
		var workingDirectory = DirectoriesMethods.DirUp(Environment.CurrentDirectory, 2);

		string dataStr_01 = File.ReadAllText(workingDirectory + "\\" + "data_01.txt");
		string dataStr_02 = File.ReadAllText(workingDirectory + "\\" + "data_02.txt");
		string dataStr_03 = File.ReadAllText(workingDirectory + "\\" + "data_03.txt");
		string dataStr_04 = File.ReadAllText(workingDirectory + "\\" + "data_04.txt");
		string dataStr_05 = File.ReadAllText(workingDirectory + "\\" + "data_05.txt");
		string dataStr_06 = File.ReadAllText(workingDirectory + "\\" + "data_06.txt");
		string dataStr_07 = File.ReadAllText(workingDirectory + "\\" + "data_07.txt");
		string dataStr_08 = File.ReadAllText(workingDirectory + "\\" + "data_08.txt");
		string dataStr_09 = File.ReadAllText(workingDirectory + "\\" + "data_09.txt");

		Parser parser = new Parser();
		Scanner_01 scanner_01 = new Scanner_01();
		Scanner_02 scanner_02 = new Scanner_02();
		Scanner_03 scanner_03 = new Scanner_03();
		Scanner_04 scanner_04 = new Scanner_04();
		Scanner_05 scanner_05 = new Scanner_05();
		Scanner_06 scanner_06 = new Scanner_06();
		Scanner_07 scanner_07 = new Scanner_07();
		Scanner_08 scanner_08 = new Scanner_08();
		Scanner_09 scanner_09 = new Scanner_09();
        Console.WriteLine(scanner_01.FindMaxElve(dataStr_01));
        Console.WriteLine(scanner_02.CalcScores(dataStr_02));
        Console.WriteLine(scanner_03.CalcScores(dataStr_03));
        Console.WriteLine(scanner_04.CalculateOverlapingSections(dataStr_04));
        scanner_05.MoveAll(dataStr_05);
        Console.WriteLine(scanner_06.FindMessageMarkerIdx(dataStr_06));
        Console.WriteLine(scanner_07.CalcDirWeight(dataStr_07));
        Console.WriteLine(scanner_08.CountAllVisibleScores(dataStr_08));
        scanner_09.MoveHead(dataStr_09);
	}
}