/* This project has had help from Jessica de Sousa (student on the course) thus some of the code may look similar - however all was completed by me and I have 
not used features of programming that I either had not heard of/ known previously or that couldn't be found using resources avaliable to me at the time of 
this project. Furthermore, I have not used anything that I was unable to explain in my report. */

using System;

namespace OOPAssgnmnt3V3
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is the main program file.
            while (true)
            {
                // Sets the default the text display to white each time.
                Console.ForegroundColor = ConsoleColor.White;

                // The code below allows the users to pick the 1st file.
                Console.WriteLine();
                Console.WriteLine("Input your command in the following format, diff fileOne.txt fileTwo.txt: ");
                string[] userInp = Console.ReadLine().Split();

                if (userInp [0] == "Exit")
                {
                    break;
                }

                try
                {
                    // Reading of the files as arrays. Links to other class.
                    FileChoice fileOne = new FileChoice(userInp[1]);
                    FileChoice fileTwo = new FileChoice(userInp[2]);

                    //Checks for the command word.
                    string message = CommandCheck.ValidCommand(userInp[0], fileOne.GetContents(), fileTwo.GetContents());
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                    }
                }
                catch(Exception)
                {
                    // Ensures that the user has the correct command in the correct format.
                    Console.WriteLine("The input command was in the wrong format/ missing compoments. Please use the following " +
                        "formats: diff fileOne.txt fileTwo.txt");
                }
            }
        }
    }
}