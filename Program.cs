﻿
namespace Game;
public class Program
{
    private static void Main(string[] args)
    {
        var game = new Game();
        game.AwaitPlayerAction();
    }
}