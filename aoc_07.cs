using System;
using System.Collections.Generic;
using System.Linq;

public class Scanner_07
{

	List<List<string>> commands = new List<List<string>>();
	List<Directory> listOfAllDirs = new List<Directory>();
	List<Directory> dirsToDelete = new List<Directory>();
	Parser parser = new Parser();

	public void GetCommands(string data)
	{
		commands = parser.CreateCommands(data);
	}
	public Directory GetCurrDir(string name, Directory directory)
	{
		Directory searchDir = new Directory();
		if (name == "..")
			searchDir = directory.parentDir;
		else
		{
			foreach (var dir in directory.subDirs)
				if (dir.dirName == name)
					searchDir = dir;
		}
		return searchDir;
	}

	public Directory CreateNewDir(string name, Directory directory)
	{
		Directory newDir = new Directory();
		newDir.dirName = name;
		newDir.parentDir = directory;
		newDir.files = new List<Tuple<int, string>>();
		newDir.subDirs = new List<Directory>();
		newDir.allSubDirs = new List<Directory>();
		directory.subDirs.Add(newDir);
		listOfAllDirs.Add(newDir);
		return newDir;
	}
	public void AddFile(List<string> command, Directory directory)
	{
		directory.files.Add(Tuple.Create(Convert.ToInt32(command[0]), command[1]));
	}
	public void CreateListDirs(string data)
	{
		GetCommands(data);
		Directory currDir = new Directory();
		currDir.dirName = "/";
		currDir.parentDir = new Directory();
		currDir.subDirs = new List<Directory>();
		currDir.allSubDirs = new List<Directory>();
		currDir.files = new List<Tuple<int, string>>();
		listOfAllDirs.Add(currDir);
		foreach (var command in commands)
		{
			if (command[0] == "$")
			{
				if (command[1] == "cd" && command[2] != "/")
					currDir = GetCurrDir(command[2], currDir);
			}
			else if (command[0] == "dir")
				CreateNewDir(command[1], currDir);
			else if (command[0].All(char.IsDigit))
				AddFile(command, currDir);
		}
	}
	public bool IsSubdirOfDirectory(Directory directory, Directory subdir)
	{
		while (true)
		{
			if (subdir.dirName == "/")
				return false;
			else if (subdir.parentDir == directory)
				return true;
			subdir = subdir.parentDir;
		}
	}
	public List<Directory> CreateAllSubdirs(Directory directory)
	{
		List<Directory> allSubdirs = new List<Directory>();
		foreach (var dir in listOfAllDirs)
		{
			if (IsSubdirOfDirectory(directory, dir))
				allSubdirs.Add(dir);
		}
		return allSubdirs;
	}
	public void CreateSubdirsForAllDirs()
	{
		foreach (var dir in listOfAllDirs)
			dir.allSubDirs = CreateAllSubdirs(dir);
	}
	public Int32 CalcDirWeight(string data)
	{
		CreateListDirs(data);
		CreateSubdirsForAllDirs();
		Int32 maxWeight = 100000;
		Int32 dirsWeighsLessMaxWeight = 0;
		Int32 discSpace = 70000000;
		Int32 updateSpace = 30000000;
		Int32 needSpace = 0;
		Int32 unusedSpace = 0;
		foreach (var dir in listOfAllDirs)
		{
			Int32 selfDirWeights = 0;
			foreach (var file in dir.files)
				selfDirWeights += file.Item1;
			Int32 allSubdirsWeights = 0;
			foreach (var subdir in dir.allSubDirs)
				foreach (var file in subdir.files)
					allSubdirsWeights += file.Item1;
			var dirWeights = selfDirWeights + allSubdirsWeights;
			dir.dirAndSubdirWeights = dirWeights;
			if (dirWeights <= maxWeight)
				dirsWeighsLessMaxWeight += dirWeights;
		}
		unusedSpace = discSpace - listOfAllDirs[0].dirAndSubdirWeights;
		needSpace = updateSpace - unusedSpace;
		foreach (var dir in listOfAllDirs)
		{
			if (dir.dirAndSubdirWeights - needSpace >= 0)
				dirsToDelete.Add(dir);
		}
		var sortedDirsToDelete = dirsToDelete.OrderBy(x => x.dirAndSubdirWeights).ToList();
		sortedDirsToDelete[0].PrintDir();
		return dirsWeighsLessMaxWeight;
	}
}