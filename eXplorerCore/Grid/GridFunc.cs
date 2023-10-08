using eXplorer.Utils;

namespace eXplorer.Grid
{
    internal static class GridFunc
    {
        public static void PrintGrid(Grid grid)
        {
            int rows = grid.GetRowCount();
            int columns = grid.GetColumnCount();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(grid.Get(i, j) + " ");
                }
                Console.WriteLine();
            }
        }

        public static void SetAllGrid(Grid grid, char val)
        {
            int rows = grid.GetRowCount();
            int columns = grid.GetColumnCount();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid.Set(i, j, val);
                }
            }
        }

        public static void SetPlayer(Grid grid, Pos pos)
        {
            grid.Previous = grid.Get(pos.Y, pos.X);
            grid.Set(pos.Y, pos.X, 'X');
        }

        // Move an entity from posfrom to posto. Must be used AFTER player set. Should NOT be used to move player unless called by player move.
        public static bool MoveEntity(Grid grid, Pos posFrom, Pos posTo)
        {
            if (posTo.X < grid.GetColumnCount() && posTo.Y < grid.GetColumnCount() && posTo.X >= 0 && posTo.Y >= 0)
            {
                char entToMove = grid.Get(posFrom.Y, posFrom.X);
                grid.Set(posFrom.Y, posFrom.X, grid.Previous);
                grid.Previous = grid.Get(posTo.Y, posTo.X);
                grid.Set(posTo.Y, posTo.X, entToMove);
                return true;
            }
            else { return false; }
        }
    }
}