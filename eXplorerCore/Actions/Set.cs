using System;
using eXplorer.Grid; // Make sure to include the appropriate namespace
using System.Collections.Generic;
using eXplorer.Player;
using eXplorer.Utils;
using System.Numerics;

namespace eXplorer.Actions
{
    static internal class Set
    {
        // Create a whitelist dictionary containing all 52 letters except 'x' and 'X'
        private static readonly Dictionary<char, bool> whitelist = new Dictionary<char, bool>();

        static Set()
        {
            // Populate the whitelist with all 52 letters except 'x' and 'X'
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c != 'X')
                {
                    whitelist[c] = true; // Adds uppercase version to the dict
                }

                if (c != 'x')
                {
                    whitelist[char.ToLower(c)] = true; // Adds lowercase version to the dict
                }
            }
        }

        public static char SetTile(Grid.Grid grid)
        {
            Console.Write("Press a character (or Backspace to exit): ");
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            char input = char.ToUpper(keyInfo.KeyChar); // Convert to uppercase

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                return ' ';
            }

            // Check if the input character is in the whitelist
            if (!whitelist.ContainsKey(input))
            {
                Graphics.Update(grid, "Invalid character");
                return SetTile(grid); // Recursively call SetTile until a valid letter is entered
            }

            grid.Previous = input;
            return input;
        }
    }
}
