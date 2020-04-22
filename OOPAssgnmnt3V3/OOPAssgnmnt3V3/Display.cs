using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssgnmnt3V3
{
    class Display
    {
        // When files == same:
        public static void NoDiff()
        {
            // Displays to te user that the files = same.
            Console.WriteLine("The files entered are the same: ");
        }
        // If the files have differences:
        public static void OutputToUser(List<Change> changesInFiles)
        {
            // lineNum var to hold the what the current line num is.
            int lineNum = 0;
            Console.WriteLine(": ");
            // Loop through all elements in the chage list.
            foreach(Change changeInFile in changesInFiles)
            {
                // Checks for empty string
                if (changeInFile.Word != string.Empty)
                {
                    //check to see if the line number needs to be updated
                    if (lineNum != changeInFile.LineNum)
                    {
                        //two blank lines added to space out the lines
                        Console.WriteLine();
                        Console.WriteLine();

                        //new line number added to the beginning of a new line before anymore of the changle list contents is displayed 
                        Console.Write($":> Line: {changeInFile.LineNum}", Console.ForegroundColor = ConsoleColor.Blue);

                        //line number counter increased to mathc the line number just displayed
                        lineNum = changeInFile.LineNum;
                    }
                    //the next word displayed on the same line in the correct corrisponding colour
                    Console.Write($" {changeInFile.Word} ", Console.ForegroundColor = changeInFile.WordColour);
                }
            }
            //once the file has displayed everything  a blank line is added
            Console.WriteLine();

            //the foreground colour is reset 
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}