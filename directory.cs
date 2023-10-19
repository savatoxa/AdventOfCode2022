using System;
using System.Collections.Generic;
using System.Linq;

public class Directory
{
	public string dirName;
	public Directory parentDir;
	public List<Directory> subDirs;
	public List<Directory> allSubDirs;
	public List<Tuple<Int32, string>> files;
	public Int32 dirAndSubdirWeights = 0;

	public bool PrintDir()
	{
		var subDirsStr = String.Join(", ", subDirs.Select(t => t.dirName));
		var filesStr = string.Join(", ", files.Select(t => string.Format("[ '{0}', '{1}']", t.Item1, t.Item2)));
		Console.WriteLine("{0}, {1}, {2}, {3}, {4}", "dirName: " + dirName, "parentDirName: " + parentDir.dirName, "subDirsNames: " + subDirsStr, "files: " + filesStr,
			"dirAndSubDirWeights: " + dirAndSubdirWeights);
		return true;
	}
	public bool PrintAllSubDirs()
	{
		string allSubDirsStr = "";
		foreach (var dir in allSubDirs)
			allSubDirsStr += ", " + dir.dirName;
		Console.WriteLine("{0}, {1}", "dirName: " + dirName, "allSubDirsNames: " + allSubDirsStr);
		return true;
	}
}
