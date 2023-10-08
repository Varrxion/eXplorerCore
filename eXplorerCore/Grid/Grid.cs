namespace eXplorer.Grid
{
    internal class Grid
    {
        // Private 2D array
        private char[,] data;
        private char previous;

        public char Previous
        {
            get { return previous; }
            set { previous = value; }
        }

    // Default to 2x2 grid
    public Grid() : this(2, 2)
        {
        }

        // Override constructor to specify size
        public Grid(int rows, int columns)
        {
            data = new char[rows, columns];
        }

        // Getter method to access an element in the grid
        public char Get(int row, int column)
        {
            if (row >= 0 && row < data.GetLength(0) && column >= 0 && column < data.GetLength(1))
            {
                return data[row, column];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid row or column index");
            }
        }

        // Setter method to modify an element in the grid
        public void Set(int row, int column, char value)
        {
            if (row >= 0 && row < data.GetLength(0) && column >= 0 && column < data.GetLength(1))
            {
                data[row, column] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid row or column index");
            }
        }

        public int GetRowCount()
        {
            return data.GetLength(0);
        }

        public int GetColumnCount()
        {
            return data.GetLength(1);
        }
    }
}