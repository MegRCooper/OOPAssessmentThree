using OOPAssgnmnt3V3.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssgnmnt3V3
{
    public class CommandCheck
    {
        // Checks that the two files both exist before trying to find diff.
        private static string FileExist(string[] fileOne, string[] fileTwo)
        {
            // Ensures the files arr isnt empty
            if (fileOne.Length == 0 || fileTwo.Length == 0)
            {
                // returns an output letting the user know the file couldn't be found
                return ("OUTPUT: One of the files selected could not be found!");
            }
            else
            {
                // Checks for differences in the files then creates a list var.
                List<Change> changesInFiles = new DetailedDiff().Changes(fileOne, fileTwo, Actions.Addition);
                // If the file returned contains values and isn't empty.
                if (changesInFiles.Count > 0)
                {
                    changesInFiles = HelperFunc.SetLineNum(changesInFiles);
                    // Outputs the diffs to the user.
                    Display.OutputToUser(changesInFiles);
                    //Creates a log file to hold all differences found.
                    LogFile.FileCreation(changesInFiles);
                }
                else
                {
                    //If there are no changes a diff display func is called.
                    Display.NoDiff();
                }
                // Returns an empty str if the displaying and logfile creation was successful.
                return (string.Empty);
            }
        }
        // Checks command word entered by the user.
        public static string ValidCommand(string Command, string[] fileOne, string[] fileTwo)
        {
            switch (Command)
            {
                //When the command diff is given:
                case "diff":
                    // Returns the test for file exists and returns any error messages that may be needed.
                    return (FileExist(fileOne, fileTwo));
                // When the input isn't diff, an error message is displayed.
                default:
                    return ("OUTPUT: Unkown Command.");

            }
        }
    }
}