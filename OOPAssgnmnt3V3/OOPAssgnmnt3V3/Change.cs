using OOPAssgnmnt3V3.Enums;
using System;

namespace OOPAssgnmnt3V3
{
    // Constructor for the list attributes that can be assigned to a single entry.
    public class Change
    {
        public string Word { get; set; }
        public int Pos { get; set; }
        public int LineNum { get; set; } = 0;
        public Actions Action { get; set; }
        public ConsoleColor WordColour { get; set; }
    }
}
