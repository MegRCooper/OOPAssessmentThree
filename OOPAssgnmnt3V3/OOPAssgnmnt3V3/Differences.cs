using OOPAssgnmnt3V3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssgnmnt3V3
{
    // Basic class for checking if the files are  different
    public class Diff
    {
        // Set the display to while during the basic diff.
        public void DisplayColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public virtual List<Change> Changes(string[] fileOne, string[] fileTwo, Actions action)
        {
            List<Change> changeList = new List<Change>();
            if (Enumerable.SequenceEqual (fileOne, fileTwo))
            {
                // If text matches then the text is turned green and the user is told that the files are the same. 
                return (changeList);
            }
            else
            {
                // Returns to show that the files are diff, the content of the files isnt relevent at this point.
                changeList.Add(new Change { Word = "Different" });
                return (changeList);
            }
        }
    }
    // Class detailing diffs in the files.
    public class DetailedDiff : Diff
    {
        //Overrides the display colour from parent class to green.
        public void OverrideDisColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public override List<Change> Changes(string[] fileOne, string[] fileTwo, Actions action)
        {
            int[] changes = new int[] { };
            List<Change> changeList = new List<Change>();

            if (Enumerable.SequenceEqual(fileOne, fileTwo))
            {
                //if it is a match the text becomes green and the user is told the files are the same
                return changeList;
            }
            else
            {
                int positionFileTwo = 0; //shows the current place in the original file
                int positionFileOne = 0; //shows the current place in the edited file

                //set the line number to 1 to start
                int LineNumber = 1;

                //to loop through all the values in the original array
                while (!HelperFunc.EndOfFile(fileTwo, positionFileTwo) && !HelperFunc.EndOfFile(fileOne, positionFileOne))
                {
                    if (fileTwo[positionFileTwo] == string.Empty)
                    {
                        //increase of line number
                        LineNumber++;
                    }

                    if (fileOne[positionFileOne] == fileTwo[positionFileTwo])//for when the values are the same
                    {
                        //both positions are increased and the word is marked as unchanged in the changeList
                        changeList.Add(HelperFunc.ReadUnchanged(fileOne, positionFileOne));
                        positionFileTwo++;
                        positionFileOne++;
                        continue;
                    }
                    else
                    {
                        //list created to hold possible additions that the application has come across in the file
                        List<Change> possibleAdditions = HelperFunc.ReadAhead(fileTwo[positionFileTwo], fileOne, positionFileOne, Actions.Addition, ConsoleColor.Green);

                        //list created to hold possible Removals that the application has come across in the file
                        List<Change> possibleRemovals = HelperFunc.ReadAhead(fileOne[positionFileOne], fileTwo, positionFileTwo, Actions.Removal, ConsoleColor.Red);
                        List<Change> MergedChanges = HelperFunc.MergeReadAhead(possibleAdditions, possibleRemovals);

                        changeList.AddRange(MergedChanges);

                        positionFileOne += MergedChanges.Count(x => x.Action != Actions.Removal);
                        positionFileTwo += MergedChanges.Count(x => x.Action != Actions.Addition);
                    }
                }

                //if the ends of either of the files have been reached
                //if it is not the end of file 1
                if (!HelperFunc.EndOfFile(fileTwo, positionFileTwo))
                {
                    //the rest of file two is added and they are marked as removals as they are not in the first file as it has no contents left ot check
                    changeList.AddRange(HelperFunc.ReadToEnd(fileTwo, positionFileTwo, Actions.Removal, ConsoleColor.Red));
                }

                //if the end of file 1 has not been reached
                if (!HelperFunc.EndOfFile(fileOne, positionFileOne))
                {
                    //the rest of file two is added and they are marked as removals as they are not in the first file as it has no contents left ot check
                    changeList.AddRange(HelperFunc.ReadToEnd(fileOne, positionFileOne, Actions.Addition, ConsoleColor.Green));
                }

                //the changelist is returned
                return changeList;
            }
        }
    }
}
