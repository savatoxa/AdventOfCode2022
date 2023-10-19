using System.Linq;


public class Scanner_06
{
	public int FindPacketMarkerIdx(string data)
	{
		int marker = 0;
		for (int i = 0; i < data.Length - 3; i++)
		{
			if (data[i] != data[i + 1] && data[i] != data[i + 2] && data[i] != data[i + 3] && data[i + 1] != data[i + 2] && data[i + 1] != data[i + 3] && data[i + 2] != data[i + 3])
			{
				marker = i;
				break;
			}
		}
		return marker + 4;
	}

	public bool IfAllDifferent(string str)
	{
		int i = 0;
		while (!str.Substring(i + 1, str.Count() - i - 1).Contains(str[i]))
		{
			if (i == str.Count() - 2)
				return true;
			i++;
		}
		return false;
	}

	public int FindMessageMarkerIdx(string data)
	{
		int mesLen = 14;
		for (int i = 0; i < data.Length - mesLen - 1; i++)
			if (IfAllDifferent(data.Substring(i, mesLen)))
				return i + mesLen;
		return 0;
	}

}
