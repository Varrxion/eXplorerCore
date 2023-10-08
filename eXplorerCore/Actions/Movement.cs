using eXplorer.Grid;
using eXplorer.Player;
using System;
using System.Collections.Generic;

namespace eXplorer.Actions
{
    static internal class Movement
    {
        private static readonly Dictionary<ConsoleKey, string> KeyToDirectionMap = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.W, "up" },
            { ConsoleKey.S, "down" },
            { ConsoleKey.A, "left" },
            { ConsoleKey.D, "right" },
            { ConsoleKey.Backspace, "exit" }
        };

        public static string MoveMode(Player.Player player, Grid.Grid grid)
        {
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Utils.Graphics.Update(grid, "Movement Mode");
                Utils.Graphics.PrintPlayerPos(player);
                Console.Write("Press WASD to move or Backspace to exit: ");
                keyInfo = Console.ReadKey(intercept: true);

                if (KeyToDirectionMap.ContainsKey(keyInfo.Key))
                {
                    string direction = KeyToDirectionMap[keyInfo.Key];

                    if (direction == "exit")
                    {
                        Console.WriteLine("Exiting movement mode.");
                        return "Moved";
                    }
                    else
                    {
                        player.Move(grid, direction);
                    }
                }
            }
        }
    }
}
