namespace eXplorer.Utils
{
    internal class Pos
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}