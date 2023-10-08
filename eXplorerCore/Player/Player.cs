using eXplorer.Utils;

namespace eXplorer.Player
{
    internal class Player
    {
        public Pos Position { get; set; }

        // Constructor for Player that initializes Pos
        public Player(int initialX, int initialY)
        {
            Position = new Pos(initialX, initialY);
        }

        public bool Move(Grid.Grid grid, string direction)
        {
            if (direction == "up")
            {
                if(Grid.GridFunc.MoveEntity(grid, Position, new Pos(Position.X, Position.Y - 1)))
                {
                    Position.Y = Position.Y - 1;
                    return true;
                }
            }
            else if (direction == "down")
            {
                if (Grid.GridFunc.MoveEntity(grid, Position, new Pos(Position.X, Position.Y + 1)))
                {
                    Position.Y = Position.Y + 1;
                    return true;
                }
            }
            else if (direction == "left")
            {
                if (Grid.GridFunc.MoveEntity(grid, Position, new Pos(Position.X - 1, Position.Y)))
                {
                    Position.X = Position.X - 1;
                    return true;
                }
            }
            else if (direction == "right")
            {
                if (Grid.GridFunc.MoveEntity(grid, Position, new Pos(Position.X + 1, Position.Y)))
                {
                    Position.X = Position.X + 1;
                    return true;
                }
            }
            return false;
        }
    }
}