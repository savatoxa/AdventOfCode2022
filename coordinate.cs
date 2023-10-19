using System;

public class Coordinate
{
    public int x;
    public int y;
    public bool PrintCoordinate()
    {
        Console.WriteLine("{0}, {1}", "x: " + x.ToString(), "y: " + y.ToString());
        return true;
    }
}
