using System;
using System.Collections.Generic;

public class Scanner_09
{
    List<Tuple<string, int>> commands = new List<Tuple<string, int>>();
    List<Coordinate> headmoves = new List<Coordinate>();
    List<Coordinate> tailmoves = new List<Coordinate>();
    Coordinate posinit = new Coordinate() { x = 0, y = 0 };
    Coordinate posnull = new Coordinate() { x = -9999, y = 9999 };
    int snakelen = 10;

    Parser parser = new Parser();

    public void GetCommands(string data)
    {
        commands = parser.CreateCommandsHead(data);
    }
    public void HeadMoves(Tuple<string, int> command)
    {
        var direction = command.Item1;
        switch (direction)
        {
            case "R":
                for (var i = 1; i <= command.Item2; i++)
                    headmoves.Add(new Coordinate() { x = headmoves[headmoves.Count - 1].x + 1, y = headmoves[headmoves.Count - 1].y });
                break;
            case "U":
                for (var i = 1; i <= command.Item2; i++)
                    headmoves.Add(new Coordinate() { x = headmoves[headmoves.Count - 1].x, y = headmoves[headmoves.Count - 1].y + 1 });
                break;
            case "L":
                for (var i = 1; i <= command.Item2; i++)
                    headmoves.Add(new Coordinate() { x = headmoves[headmoves.Count - 1].x - 1, y = headmoves[headmoves.Count - 1].y });
                break;
            case "D":
                for (var i = 1; i <= command.Item2; i++)
                    headmoves.Add(new Coordinate() { x = headmoves[headmoves.Count - 1].x, y = headmoves[headmoves.Count - 1].y - 1 });
                break;
        }
    }
    public void MoveHead(string data)
    {
        GetCommands(data);
        headmoves.Add(posinit);
        foreach (var command in commands)
            HeadMoves(command);

        MoveTail(headmoves);
        var tailmovesNoRepeats = GetPosesNoRepeats(tailmoves);
        //tailmoves.ForEach(m => m.PrintCoordinate());
        //Console.WriteLine(tailmoves.Count);
        Console.WriteLine(tailmovesNoRepeats.Count);

    }
    public List<Coordinate> GetPosesNoRepeats(List<Coordinate> poses)
    {
        List<Coordinate> posesNoRepeats = new List<Coordinate>();
        foreach (var coord in poses)
        {
            bool contains = false;
            foreach (var coordnr in posesNoRepeats)
            {
                if (coord.x == coordnr.x && coord.y == coordnr.y)
                {
                    contains = true;
                    continue;
                }
            }
            if (!contains)
                posesNoRepeats.Add(coord);
        }
        return posesNoRepeats;
    }

    public bool NoTouch(Coordinate tail, Coordinate head)
    {
        if (tail.x == head.x && tail.y == head.y)
            return false;
        if (tail.x + 1 == head.x && tail.y == head.y)
            return false;
        if (tail.x + 1 == head.x && tail.y + 1 == head.y)
            return false;
        if (tail.x == head.x && tail.y + 1 == head.y)
            return false;
        if (tail.x - 1 == head.x && tail.y + 1 == head.y)
            return false;
        if (tail.x - 1 == head.x && tail.y == head.y)
            return false;
        if (tail.x - 1 == head.x && tail.y - 1 == head.y)
            return false;
        if (tail.x == head.x && tail.y - 1 == head.y)
            return false;
        if (tail.x + 1 == head.x && tail.y - 1 == head.y)
            return false;
        return true;
    }
    public List<Coordinate> possiblemovesDiag(Coordinate tailpos)
    {
        List<Coordinate> possiblemoves = new List<Coordinate>();
        possiblemoves.Add(new Coordinate() { x = tailpos.x + 1, y = tailpos.y + 1 });
        possiblemoves.Add(new Coordinate() { x = tailpos.x - 1, y = tailpos.y + 1 });
        possiblemoves.Add(new Coordinate() { x = tailpos.x - 1, y = tailpos.y - 1 });
        possiblemoves.Add(new Coordinate() { x = tailpos.x + 1, y = tailpos.y - 1 });
        return possiblemoves;
    }
    public List<Coordinate> possiblemovesCross(Coordinate tailpos)
    {
        List<Coordinate> possiblemoves = new List<Coordinate>();
        possiblemoves.Add(new Coordinate() { x = tailpos.x, y = tailpos.y + 1 });
        possiblemoves.Add(new Coordinate() { x = tailpos.x - 1, y = tailpos.y });
        possiblemoves.Add(new Coordinate() { x = tailpos.x, y = tailpos.y - 1 });
        possiblemoves.Add(new Coordinate() { x = tailpos.x + 1, y = tailpos.y });
        return possiblemoves;
    }
    public Coordinate MoveSnake(Coordinate second, Coordinate first)
    {
        if (NoTouch(second, first))
        {
            if (second.x == first.x || second.y == first.y)
                foreach (var pm in possiblemovesCross(second))
                    if (!NoTouch(pm, first))
                        return pm;
            foreach (var pm in possiblemovesDiag(second))
                if (!NoTouch(pm, first))
                    return pm;
        }
        return posnull;
    }
    public void MoveTail(List<Coordinate> headposes)
    {
        List<Coordinate> snake = new List<Coordinate>();
        for (var i = 0; i < snakelen; i++)
            snake.Add(posinit);
        tailmoves.Add(posinit);
        for (var i = 0; i < headposes.Count; i++)
        {
            snake[0] = headposes[i];
            for (var j = 0; j < snakelen - 1; j++)
            {
                var posres = MoveSnake(snake[j + 1], snake[j]);
                if (posres != posnull)
                    snake[j + 1] = posres;
            }
            if (tailmoves[tailmoves.Count - 1] != snake[snakelen - 1])
                tailmoves.Add(snake[snakelen - 1]);
        }
    }
}
