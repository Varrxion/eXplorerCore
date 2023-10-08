using System;

namespace eXplorer.Utils
{
    [Serializable]
    internal class Config
    {
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }
        public PlayerStartPosition PlayerStartPosition { get; set; }
    }

    internal class PlayerStartPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
