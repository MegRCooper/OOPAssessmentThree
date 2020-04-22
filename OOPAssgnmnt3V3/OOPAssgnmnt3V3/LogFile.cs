using System;
using System.Collections.Generic;
using System.IO;

namespace OOPAssgnmnt3V3
{
    public class LogFile
    {
        //method collects the file path used to create a file for the log information
        public static string GetLogFile()
        {
            return ($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\LogFile.txt");
        }

        //method that write contents to the log file
        public static void FileCreation(List<Change> differencesList)
        {
            //uses stream reader to be able to write into the file
            using (StreamWriter writer = new StreamWriter(GetLogFile()))
            {
                //each value from the given list are written into the file 
                foreach (Change changeInFile in differencesList)
                {
                    writer.WriteLine();
                    writer.WriteLine($"Line Number: {changeInFile.LineNum} ");
                    writer.WriteLine($"Action used: {changeInFile.Action}");
                    writer.WriteLine($"Word: {changeInFile.Word}");
                    writer.WriteLine();
                }
            }
        }
    }
}
