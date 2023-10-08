using eXplorer.Grid;
using eXplorer.Player;
using eXplorer.Utils;
using eXplorer.Actions;

namespace eXplorer
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            // Create the instanced objects
            Config config = ConfigLoader.LoadConfig();
            Grid.Grid mainGrid;
            Player.Player player;

            if (config != null) // If the config is found, load it
            {
                mainGrid = new Grid.Grid(config.GridHeight, config.GridWidth);
                player = new Player.Player(config.PlayerStartPosition.X, config.PlayerStartPosition.Y);
            }
            else // Fallback if no config found.
            {
                mainGrid = new Grid.Grid(3, 3);
                player = new Player.Player(0, 0);
            }

            GridFunc.SetAllGrid(mainGrid, '?');
            GridFunc.SetPlayer(mainGrid, player.Position);


            string status = "New Grid, Press H for Help";
            Graphics.Update(mainGrid, status);

            bool loop = true;
            Dictionary<ConsoleKey, Func<string>> validCommands = new Dictionary<ConsoleKey, Func<string>>
            {
                { ConsoleKey.H, () => Help.ListHelp() },
                { ConsoleKey.M, () => Movement.MoveMode(player, mainGrid) },
                { ConsoleKey.S, () =>
                    {
                        Utils.Graphics.Update(mainGrid, "Set Mode");
                        Utils.Graphics.PrintPlayerPos(player);
                        return "You have placed: " + Set.SetTile(mainGrid);
                    }
                },
                { ConsoleKey.Escape, () => { loop = false; return "Exiting..."; } } // Exit with Esc key
            };

            while (loop)
            {
                Console.Write("Press a command key (Esc to quit): ");
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (validCommands.TryGetValue(keyInfo.Key, out Func<string> action))
                {
                    status = action.Invoke();
                }
                else
                {
                    status = "Key not recognized";
                }

                Graphics.Update(mainGrid, status);
            }
        }
    }
}