using System.Collections.Generic;

namespace OOPAssgnmnt3V3
{
    public class FileChoice
    {
        private string[] File { get; set; }
        
        // Constructors for the file vars. 
        public FileChoice(string fileName)
        {
            File = GetFile(fileName);
        }

        // Getter for file contents.
       public string[] GetContents()
        {
            return (File);
        }

        // Func that removes the line gap as this doesn't influence the files contents.
        private static string[] RemoveSpaces(string[] file)
        {
            // New list created to hold the editied file contents.
            List<string> changedFile = new List<string> { };
            // Loops through all the values in the curret file.
            for (int i = 0; i < file.Length; i++)
            {
                // Checks for the num of blank spaces, if its a single then the val is added to the list.
                if (!(file[i] == string.Empty && file[i + 1] == string.Empty))
                {
                    changedFile.Add(file[i]);
                }
                // If theres three blanks in a row. Val added to list. 
                else if (file[i] == string.Empty && file[i + 1] == string.Empty && file[i + 2] == string.Empty)
                {
                    //Two blanks are added to the file while the other is discarded. 
                    //i is incremented by two to ensure its not added to the list.
                    changedFile.Add(file[i]);
                    changedFile.Add(file[i + 1]);
                    i += 2;
                }
            }
            // List converted to arr and then returned.
            return changedFile.ToArray();
        }

        /* Assigns the users choice of file and converts the arr to a string each time. 
        The string is then returned to be used in the comparison functions. */
        public static string[] GetFile(string fileOp)
        {
            string[] file = new string[] { };

            switch (fileOp)
            {
                //the file corrispoding with the user input is appended into the file vars
                case "GitRepositories_1a.txt":
                    file = Properties.Resources.GitRepositories_1a.Split();
                    break;

                case "GitRepositories_1b.txt":
                    file = Properties.Resources.GitRepositories_1b.Split();
                    break;

                case "GitRepositories_2a.txt":
                    file = Properties.Resources.GitRepositories_2a.Split();
                    break;

                case "GitRepositories_2b.txt":
                    file = Properties.Resources.GitRepositories_2b.Split();
                    break;

                case "GitRepositories_3a.txt":
                    file = Properties.Resources.GitRepositories_3a.Split();
                    break;

                case "GitRepositories_3b.txt":
                    file = Properties.Resources.GitRepositories_3b.Split();
                    break;
            }
            // Removes the line gap as this doesn't influence the files contents.
            return RemoveSpaces(file);
        }
    }
}
