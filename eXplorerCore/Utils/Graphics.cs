using eXplorer.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXplorer.Utils
{
    static internal class Graphics
    {
        public static void Update(Grid.Grid grid, string status)
        {
            Console.Clear();
            Console.WriteLine(status);
            GridFunc.PrintGrid(grid);
        }

        public static void PrintPlayerPos(Player.Player player)
        {
            Console.WriteLine(player.Position.X + "<X Y>" + player.Position.Y);
        }
    }
}
